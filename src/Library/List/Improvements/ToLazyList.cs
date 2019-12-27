namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class FastLinq
    {
        // TODO: ToListLazy might be more discoverable
        /// <summary>
        ///     Creates a lazy <see cref="IList{T}" /> that can be index accessed cheaply and enumerated lazily.
        ///     However, Writing to the list will trigger a copy-on-write operation and eager-load the list rather than being lazy.
        ///     Note that as a lazy list - enumeration over the whole list will be slower than enumeration over
        ///     <see cref="List{T}" /> since the <see cref="List{T}.Enumerator" /> enumerator can be inlined
        ///     -
        ///     When to use:
        ///     * There are any times when you will not be writing to the list
        ///       - note this does not say "you will never be writing to the list"
        ///       - if you will ALWAYS be writing, just use <see cref="Enumerable.ToList{T}"/>, since this will call it anyway
        ///     * One of the following
        ///      ** You only need direct access to a few items in the list
        ///      ** You will often not enumerate the list
        ///      ** Memory is more important than enumeration speed (avoids copying like Enumerable.ToList
        ///         - but with extra conditionals during enumeration.)
        ///     -
        ///     In testing, enumeration latency is about 3x, but memory footprint is static (O(1)) regardless of length of source.
        /// </summary>
        // TODO: The use cases for this are elisive to me at the present time, so not exposing to the end user.
        // TODO: If you make this non-internal, need to benchmark CopyOnWriteList
        internal static IFastLinqLazyList<T> ToLazyList<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new CopyOnWriteList<T>(
                source);
        }

        /// <summary>
        ///     Interface for <see cref="FastLinq.ToLazyList{T}" /> with efficient <see cref="IEnumerable{T}.GetEnumerator" />
        /// </summary>
        internal interface IFastLinqLazyList<T> : IList<T>
        {
            new FastLinqLazyListEnumerator<T> GetEnumerator();
        }

        internal struct FastLinqLazyListEnumerator<T> : IEnumerator<T>
        {
            private List<T>.Enumerator listEnumerator;
            private IEnumerator<T> genericEnumerator;

            public FastLinqLazyListEnumerator(
                List<T>.Enumerator? listEnumerator,
                IEnumerator<T> genericEnumerator)
            {
                this.listEnumerator = listEnumerator ?? default(List<T>.Enumerator);
                this.genericEnumerator = genericEnumerator;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (this.genericEnumerator != null)
                {
                    return this.genericEnumerator.MoveNext();
                }

                return this.listEnumerator.MoveNext();
            }

            public void Reset()
            {
                if (this.genericEnumerator != null)
                {
                    this.genericEnumerator.Reset();
                    return;
                }

                ((IEnumerator) this.listEnumerator).Reset();
            }

            public T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (this.genericEnumerator != null)
                    {
                        return this.genericEnumerator.Current;
                    }

                    return this.listEnumerator.Current;
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                if (this.genericEnumerator != null)
                {
                    this.genericEnumerator.Dispose();
                    return;
                }

                this.listEnumerator.Dispose();
            }
        }

        private sealed class CopyOnWriteList<T> : IFastLinqLazyList<T>, IReadOnlyList<T>
        {
            private List<T> _copiedList;
            private IReadOnlyList<T> _listImplementation;
            private readonly object copyLock = new object();

            public CopyOnWriteList(IReadOnlyList<T> listImplementation)
            {
                this._listImplementation = listImplementation;
            }

            private bool IsCopied
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get { return this._copiedList != null; }
            }

            public void Add(T item)
            {
                this.WriteRequested();
                this._copiedList.Add(item);
            }

            public void Clear()
            {
                this.WriteRequested();
                this._copiedList.Clear();
            }

            public bool Contains(T item)
            {
                if (this.IsCopied)
                {
                    return this._copiedList.Contains(item);
                }

                return this._listImplementation.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                if (this.IsCopied)
                {
                    this._copiedList.CopyTo(array, arrayIndex);
                    return;
                }

                if (this._listImplementation is ICollection<T> collection)
                {
                    collection.CopyTo(array, arrayIndex);
                    return;
                }

                // Inefficient implementation
                var index = 0;
                foreach (T item in this._listImplementation) // TODO: accessing directly via this[index] is probably typically faster
                {
                    array[index++ + arrayIndex] = item;
                }
            }

            public bool Remove(T item)
            {
                this.WriteRequested();
                return this._copiedList.Remove(item);
            }

            public int Count
            {
                get
                {
                    if (this.IsCopied)
                    {
                        return this._copiedList.Count;
                    }

                    return this._listImplementation.Count;
                }
            }

            public bool IsReadOnly => false;

            FastLinqLazyListEnumerator<T> IFastLinqLazyList<T>.GetEnumerator()
            {
                return new FastLinqLazyListEnumerator<T>(
                    this._copiedList?.GetEnumerator(),
                    this._listImplementation?.GetEnumerator());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new FastLinqLazyListEnumerator<T>(
                    this._copiedList?.GetEnumerator(),
                    this._listImplementation?.GetEnumerator());
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return new FastLinqLazyListEnumerator<T>(
                    this._copiedList?.GetEnumerator(),
                    this._listImplementation?.GetEnumerator());
            }

            public int IndexOf(T item)
            {
                if (this.IsCopied)
                {
                    return this._copiedList.IndexOf(item);
                }

                if (this._listImplementation is IList<T> list)
                {
                    return list.IndexOf(item);
                }

                int listCount = this._listImplementation.Count;
                for (var index = 0; index < listCount; index++)
                {
                    if (Equals(item, this._listImplementation[index]))
                    {
                        return index;
                    }
                }

                return -1;
            }

            public void Insert(int index, T item)
            {
                this.WriteRequested();
                this._copiedList.Insert(index, item);
            }

            public void RemoveAt(int index)
            {
                this.WriteRequested();
                this._copiedList.RemoveAt(index);
            }

            public T this[int index]
            {
                get
                {
                    if (this.IsCopied)
                    {
                        return this._copiedList[index];
                    }

                    return this._listImplementation[index];
                }
                set
                {
                    this.WriteRequested();
                    this._copiedList[index] = value;
                }
            }

            private void WriteRequested()
            {
                // Only incur the lock on the first write
                if (!this.IsCopied)
                {
                    lock (this.copyLock)
                    {
                        // Double-check locking
                        if (!this.IsCopied)
                        {
                            this._copiedList = new List<T>(this._listImplementation);
                            this._listImplementation = null;
                        }
                    }
                }
            }
        }
    }
}