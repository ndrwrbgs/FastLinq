namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        internal static IReadOnlyCollection<T> ToCollection<T>(
            this IEnumerable<T> source,
            int knownSize)
        {
            return new EnumerableWithCount<T>(
                source,
                knownSize);
        }
    }
}