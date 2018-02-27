using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class FastLinq
    {
        public static ICollection<TOut> Select<T, TOut>(
            this ICollection<T> source,
            Func<T, TOut> projection)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (projection == null)
            {
                throw new ArgumentNullException(nameof(projection));
            }
            return new EnumerableWithCount<TOut>(
                Enumerable.Select(source, projection),
                source.Count);
        }

        public static ICollection<TOut> Select<T, TOut>(
            this ICollection<T> source,
            Func<T, int, TOut> projection)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (projection == null)
            {
                throw new ArgumentNullException(nameof(projection));
            }
            return new EnumerableWithCount<TOut>(
                Enumerable.Select(source, projection),
                source.Count);
        }
    }
}
