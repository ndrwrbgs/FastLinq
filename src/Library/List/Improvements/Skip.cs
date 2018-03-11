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
        public static IReadOnlyList<T> Skip<T>(
            this IReadOnlyList<T> source,
            int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new SkipList<T>(
                source,
                count);
        }

        private sealed class SkipList<T> : IReadOnlyList<T>
        {
            private static T[] Empty = new T[]{};

            private readonly IReadOnlyList<T> list;
            private readonly int skip;

            public SkipList(IReadOnlyList<T> list, int skip)
            {
                if (skip >= list.Count)
                {
                    this.list = Empty;
                    this.skip = 0;
                    return;
                }

                if (skip < 0)
                {
                    // Analogous to what the BCL does
                    skip = 0;
                }

                this.list = list;
                this.skip = skip;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                var listCount = this.list.Count;
                for (int i = skip; i < listCount; i++)
                {
                    yield return this.list[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            
            public int Count => this.list.Count - this.skip;
            public T this[int index]
            {
                get => this.list[index + this.skip];

                set => throw new NotSupportedException();
            }
        }
    }
}
