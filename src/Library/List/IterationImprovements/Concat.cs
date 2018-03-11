namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IReadOnlyList<TSource> Concat<TSource>(
            this IReadOnlyList<TSource> source,
            IReadOnlyList<TSource> other)
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

        private sealed class ConcatList<T> : IReadOnlyList<T>
        {
            private readonly IReadOnlyList<T> first;
            private readonly IReadOnlyList<T> second;

            public ConcatList(IReadOnlyList<T> first, IReadOnlyList<T> second)
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
            
            public int Count => this.first.Count + this.second.Count;
            
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