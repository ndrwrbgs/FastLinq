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
        internal static IReadOnlyList<TResult> Zip<TFirst, TSecond, TResult>(
            this IReadOnlyList<TFirst> first,
            IReadOnlyList<TSecond> second,
            Func<TFirst, TSecond, TResult> resultFunc)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (resultFunc == null)
            {
                throw new ArgumentNullException(nameof(resultFunc));
            }

            return new ZipList<TFirst, TSecond, TResult>(
                first,
                second,
                resultFunc);
        }

        private sealed class ZipList<TFirst, TSecond, TResult> : IReadOnlyList<TResult>
        {
            private readonly IReadOnlyList<TFirst> first;
            private readonly IReadOnlyList<TSecond> second;
            private readonly Func<TFirst, TSecond, TResult> resultFunc;

            public ZipList(
                IReadOnlyList<TFirst> first,
                IReadOnlyList<TSecond> second,
                Func<TFirst, TSecond, TResult> resultFunc)
            {
                this.first = first;
                this.second = second;
                this.resultFunc = resultFunc;
            }

            public IEnumerator<TResult> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<TResult> GetEnumerable()
            {
                // TODO: Is it faster to implement an enumerator?
                // TODO: It's probably one less object allocation
                var count = this.Count;
                for (int i = 0; i < count; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public int Count => Math.Min(this.first.Count, this.second.Count);

            public TResult this[int index]
            {
                get
                {
                    var firstItem = this.first[index];
                    var secondItem = this.second[index];

                    return this.resultFunc(firstItem, secondItem);
                }
            }
        }
    }
}
