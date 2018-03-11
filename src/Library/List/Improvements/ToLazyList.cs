namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        // TODO: Memoize the results to mitiate multiple invokations of .Select?
        // TODO: Internal b/c I broke it for right now.
        internal static IList<T> ToLazyList<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CopyOnWriteList<T>(
                source);
        }

        private sealed class CopyOnWriteList<T> : IList<T>
        {
            private IList<T> _listImplementation;
            private bool isCopied = false;
            private object copyLock = new object();

            public CopyOnWriteList(IReadOnlyList<T> listImplementation)
            {
                // TODO this._listImplementation = listImplementation;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this._listImplementation.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable) this._listImplementation).GetEnumerator();
            }

            public void Add(T item)
            {
                this.WriteRequested();
                this._listImplementation.Add(item);
            }

            private void WriteRequested()
            {
                // Only incur the lock on the first write
                if (!this.isCopied)
                {
                    lock (this.copyLock)
                    {
                        // Double-check locking
                        if (!this.isCopied)
                        {
                            this._listImplementation = new List<T>(this._listImplementation);
                            this.isCopied = true;
                        }
                    }
                }
            }

            public void Clear()
            {
                this.WriteRequested();
                this._listImplementation.Clear();
            }

            public bool Contains(T item)
            {
                return this._listImplementation.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                this._listImplementation.CopyTo(array, arrayIndex);
            }

            public bool Remove(T item)
            {
                this.WriteRequested();
                return this._listImplementation.Remove(item);
            }

            public int Count => this._listImplementation.Count;

            public bool IsReadOnly => false;

            public int IndexOf(T item)
            {
                return this._listImplementation.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                this.WriteRequested();
                this._listImplementation.Insert(index, item);
            }

            public void RemoveAt(int index)
            {
                this.WriteRequested();
                this._listImplementation.RemoveAt(index);
            }

            public T this[int index]
            {
                get => this._listImplementation[index];
                set
                {
                    this.WriteRequested();
                    this._listImplementation[index] = value;
                }
            }
        }
    }
}