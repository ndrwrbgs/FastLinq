using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    using System.Collections;

    public static partial class FastLinq
    {
        /// <summary>
        /// May actually have some improvements due to avoiding double-copying of Buffer
        /// </summary>
        public static IList<T> Reverse<T>(
            this IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new ReverseList<T>(
                source);
        }

        private sealed class ReverseList<T> : IList<T>
        {
            private readonly IList<T> list;

            public ReverseList(IList<T> list)
            {
                this.list = list;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                for (int i = this.list.Count - 1; i >= 0; i--)
                {
                    yield return this.list[i];
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
                return this.list.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                this.list.CopyTo(array, arrayIndex);
                Array.Reverse(array, arrayIndex, this.list.Count);
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.list.Count;
            public bool IsReadOnly => true;
            public int IndexOf(T item)
            {
                // Have to manually implement this because
                // this.list's implementation will return the FIRST item,
                // which, for us, is the last item
                for (int realIndex = this.list.Count - 1; realIndex >= 0; realIndex--)
                {
                    var atIndex = this.list[realIndex];
                    if (Equals(item, atIndex))
                    {
                        // Inverse for reverse
                        return this.list.Count - realIndex - 1;
                    }
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
                    var reversedIndex = this.list.Count - index - 1;
                    return this.list[reversedIndex];
                }

                set => throw new NotSupportedException();
            }
        }
    }
}
