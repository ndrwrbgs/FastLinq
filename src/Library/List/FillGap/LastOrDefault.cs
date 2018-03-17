namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static T LastOrDefault<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int count = source.Count;
            if (count > 0)
            {
                return source[count - 1];
            }

            return default(T);
        }
    }
}