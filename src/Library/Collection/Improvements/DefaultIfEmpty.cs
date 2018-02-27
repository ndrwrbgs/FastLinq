using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class FastLinq
    {
        public static ICollection<T> DefaultIfEmpty<T>(
            this ICollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                // TODO: Ideally this could be a single reference always, but that would need a static in a generic class. Maybe later with pooling work
                return new[] { default(T) };
            }

            return source;
        }
    }
}
