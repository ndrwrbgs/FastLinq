namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static T Last<T>(
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

            throw new InvalidOperationException("Sequence contains no elements");
        }
    }
}