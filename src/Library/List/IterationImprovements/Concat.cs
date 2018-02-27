namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IList<TSource> Concat<TSource>(
            this IList<TSource> source,
            IList<TSource> other)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return new ConcatList<TSource>(
                source,
                other);
        }

        private sealed class ConcatList<T> : IList<T>
        {
            private readonly IList<T> first;
            private readonly IList<T> second;

            public ConcatList(IList<T> first, IList<T> second)
            {
                this.first = first;
                this.second = second;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                int firstCount = this.first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    yield return this.first[i];
                }

                int secondCount = this.second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    yield return this.second[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            void ICollection<T>.Add(T item)
            {
                throw new NotSupportedException();
            }

            void ICollection<T>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(T item)
            {
                return this.first.Contains(item)
                       || this.second.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                this.first.CopyTo(array, arrayIndex);
                this.second.CopyTo(array, arrayIndex + this.first.Count);
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.first.Count + this.second.Count;
            public bool IsReadOnly => true;

            public int IndexOf(T item)
            {
                int indexInFirst = this.first.IndexOf(item);
                if (indexInFirst != -1)
                {
                    return indexInFirst;
                }

                int indexInSecond = this.second.IndexOf(item);
                if (indexInSecond != -1)
                {
                    return indexInSecond + this.first.Count;
                }

                return -1;
            }

            void IList<T>.Insert(int index, T item)
            {
                throw new NotSupportedException();
            }

            void IList<T>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public T this[int index]
            {
                get
                {
                    if (index < this.first.Count)
                    {
                        return this.first[index];
                    }

                    index -= this.first.Count;
                    return this.second[index];
                }

                set => throw new NotSupportedException();
            }
        }
    }
}