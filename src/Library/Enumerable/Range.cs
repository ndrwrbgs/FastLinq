namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IReadOnlyList<int> Range(
            int start,
            int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            // TODO: Compare to
            //long num = (long)start + (long)count - 1L;
            //if (count < 0 || num > (long)int.MaxValue)
            //    throw Error.ArgumentOutOfRange(nameof(count));
            if (start >= 0 && start - 1 > int.MaxValue - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return new RangeList(start, count);
        }

        /// <summary>
        /// Needed to avoid eager memory allocation of the entire range, which is not desirable
        /// </summary>
        private sealed class RangeList : IReadOnlyList<int>
        {
            private readonly int start;

            public RangeList(int start, int count)
            {
                this.start = start;
                this.Count = count;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            // TODO: Using an enumerator would likely be more perforamnt
            private IEnumerable<int> GetEnumerable()
            {
                // TODO: Can do this better without longs and casting, but not right now
                for (long i = this.start; i < this.start + (long)this.Count; i++)
                {
                    yield return (int)i;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public int Count { get; }

            public int this[int index]
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

                    return index + this.start;
                }
            }
        }
    }
}