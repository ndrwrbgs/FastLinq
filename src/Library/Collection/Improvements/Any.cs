namespace System.Linq
{
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        internal static bool Any<T>(
            this IReadOnlyCollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Count > 0;
        }
    }
}