namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class FastLinq
    {
        // TODO: ToListLazy might be more discoverable
        public static IFastLinqLazyList<T> ToLazyList<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CopyOnWriteList<T>(
                source);
        }

        public struct LazyListEnumerator<T> : IEnumerator<T>
        {
            private readonly bool hasListEnumerator;
            private List<T>.Enumerator enumerator;
            private readonly IEnumerator<T> enumerator2;

            internal LazyListEnumerator(
                List<T> copiedList,
                IReadOnlyList<T> listImplementation)
            {
                if (copiedList != null)
                {
                    this.hasListEnumerator = true;
                    this.enumerator = copiedList.GetEnumerator();
                    this.enumerator2 = null;
                }
                else
                {
                    this.hasListEnumerator = false;
                    this.enumerator = default(List<T>.Enumerator);
                    this.enumerator2 = listImplementation.GetEnumerator();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                return this.hasListEnumerator
                    ? this.enumerator.MoveNext()
                    : this.enumerator2.MoveNext();
            }

            public void Reset()
            {
                if (this.hasListEnumerator)
                {
                    ((IEnumerator) this.enumerator).Reset();
                }
                else
                {
                    this.enumerator2.Reset();
                }
            }

            public T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return this.hasListEnumerator
                        ? this.enumerator.Current
                        : this.enumerator2.Current;
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                if (this.hasListEnumerator)
                {
                    this.enumerator.Dispose();
                }
                else
                {
                    this.enumerator2.Dispose();
                }
            }
        }

        /// <summary>
        /// Interface for <see cref="FastLinq.ToLazyList{T}"/> with efficient <see cref="IEnumerable{T}.GetEnumerator"/>
        /// </summary>
        public interface IFastLinqLazyList<T> : IList<T>
        {
            new LazyListEnumerator<T> GetEnumerator();
        }

        private sealed class CopyOnWriteList<T> : IFastLinqLazyList<T>, IReadOnlyList<T>
        {
            internal IReadOnlyList<T> _listImplementation;
            internal List<T> _copiedList;
            private object copyLock = new object();

            public CopyOnWriteList(IReadOnlyList<T> listImplementation)
            {
                this._listImplementation = listImplementation;
            }

            public LazyListEnumerator<T> GetEnumerator()
            {
                // TODO: Made this copy-on-enumerate always for performance, but is it right to do so?
                WriteRequested();

                return new LazyListEnumerator<T>(
                    this._copiedList,
                    this._listImplementation);
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                // TODO: Made this copy-on-enumerate always for performance, but is it right to do so?
                WriteRequested();

                if (this.IsCopied)
                {
                    return this._copiedList.GetEnumerator();
                }

                return this._listImplementation.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                // TODO: Made this copy-on-enumerate always for performance, but is it right to do so?
                WriteRequested();

                if (this.IsCopied)
                {
                    return ((IEnumerable)this._copiedList).GetEnumerator();
                }

                return ((IEnumerable)this._listImplementation).GetEnumerator();
            }

            internal bool IsCopied => this._copiedList != null;

            public void Add(T item)
            {
                this.WriteRequested();
                this._copiedList.Add(item);
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
                int index = 0;
                foreach (var item in this._listImplementation)  // TODO: accessing directly via this[index] is probably typically faster
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
                for (int index = 0; index < listCount; index++)
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
        }
    }
}