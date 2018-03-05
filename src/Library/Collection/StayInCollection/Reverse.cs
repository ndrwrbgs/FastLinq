using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class FastLinq
    {
        public static ICollection<T> Reverse<T>(
            this ICollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new EnumerableWithCount<T>(
                Enumerable.Reverse(source),
                source.Count);
        }
    }
}
