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
        public static IReadOnlyList<T> Take<T>(
            this IReadOnlyList<T> source,
            int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new TakeList<T>(
                source,
                count);
        }

        private sealed class TakeList<T> : IReadOnlyList<T>
        {
            private static T[] Empty = new T[]{};

            private readonly IReadOnlyList<T> list;
            private readonly int take;

            public TakeList(IReadOnlyList<T> list, int take)
            {
                if (take < 0)
                {
                    // This is analogous to what the BCL does
                    take = 0;
                }

                if (take == 0)
                {
                    this.list = Empty;
                    this.take = 0;
                    return;
                }

                this.list = list;
                this.take = Math.Min(take, this.list.Count);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            // TODO: the perf of this wasn't the greatest in the Take benchmarks. Use a custom enumerator
            private IEnumerable<T> GetEnumerable()
            {
                for (int i = 0; i < this.take; i++)
                {
                    yield return this.list[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            
            public bool Contains(T item)
            {
                // Copied from List with casting - TODO: Copy from source directly
                if ((object)item == null)
                {
                    for (int index = 0; index < this.take; ++index)
                    {
                        if ((object)this.list[index] == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                for (int index = 0; index < this.take; ++index)
                {
                    if (equalityComparer.Equals(this.list[index], item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int Count => Math.Min(this.list.Count, this.take);

            public T this[int index]
            {
                get
                {
                    if (index >= this.Count
                        || index >= this.take)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.list[index];
                }

                set => throw new NotSupportedException();
            }
        }
    }
}
