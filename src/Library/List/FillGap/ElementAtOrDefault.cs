namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static T ElementAtOrDefault<T>(
            this IReadOnlyList<T> source,
            int index)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return index >= 0 && index < source.Count 
                ? source[index] 
                : default(T);
        }
    }
}