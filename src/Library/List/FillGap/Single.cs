namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static T Single<T>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            switch (source.Count)
            {
                case 0:
                    throw new InvalidOperationException("The sequence contains no elements");
                case 1:
                    return source[0];
            }

            throw new InvalidOperationException("The sequence contains more than one element");
        }
    }
}