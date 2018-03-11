using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class FastLinq
    {
        public static IReadOnlyCollection<T> Skip<T>(
            this IReadOnlyCollection<T> source,
            int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new EnumerableWithCount<T>(
                Enumerable.Skip(source, count),
                Math.Max(0, source.Count - Math.Max(0, count)));
        }
    }
}
