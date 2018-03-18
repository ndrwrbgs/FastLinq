namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IReadOnlyList<T> Repeat<T>(
            T element,
            int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return new RepeatEnumerable<T>(
                element,
                count);
        }

        private sealed class RepeatEnumerable<T> : IReadOnlyList<T>
        {
            private readonly T element;

            public RepeatEnumerable(T element, int count)
            {
                this.element = element;
                this.Count = count;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new Enumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public int Count { get; }

            public T this[int index]
            {
                get
                {
                    if (index < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (index >= this.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.element;
                }
            }

            private struct Enumerator : IEnumerator<T>
            {
                private readonly RepeatEnumerable<T> enumerable;
                private int currentIndex;

                public Enumerator(RepeatEnumerable<T> enumerable)
                {
                    this.enumerable = enumerable;
                    this.currentIndex = 0;
                }

                public bool MoveNext()
                {
                    if (this.currentIndex < this.enumerable.Count)
                    {
                        this.currentIndex++;
                        return true;
                    }

                    return false;
                }

                public void Reset()
                {
                    this.currentIndex = 0;
                }

                public T Current => this.enumerable.element;

                object IEnumerator.Current => this.Current;

                public void Dispose()
                {
                }
            }
        }
    }
}