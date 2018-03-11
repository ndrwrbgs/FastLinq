using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class FastLinq
    {
        public static IReadOnlyCollection<TResult> Zip<TFirst, TSecond, TResult>(
            this IReadOnlyCollection<TFirst> first,
            IReadOnlyCollection<TSecond> second,
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
            return new EnumerableWithCount<TResult>(
                Enumerable.Zip(first, second, resultFunc),
                Math.Min(first.Count, second.Count));
        }
    }
}
