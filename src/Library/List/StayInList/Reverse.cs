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
        public static IReadOnlyList<T> Reverse<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new ReverseList<T>(
                source);
        }

        private sealed class ReverseList<T> : IReadOnlyList<T>, ICanCopyTo<T>
        {
            private readonly IReadOnlyList<T> list;

            public ReverseList(IReadOnlyList<T> list)
            {
                this.list = list;
            }

            public void CopyTo(long sourceIndex, T[] dest, long count)
            {
                CanCopyHelper.CopyTo(this.list, sourceIndex, dest, count);
                Array.Reverse(dest, 0, (int) count);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                // TODO: Is it faster to implement an enumerator?
                for (int i = this.list.Count - 1; i >= 0; i--)
                {
                    yield return this.list[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            
            public int Count => this.list.Count;
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
