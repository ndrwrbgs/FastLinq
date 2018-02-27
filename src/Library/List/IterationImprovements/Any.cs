namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static bool Any<T>(
            this IList<T> source,
            Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));}

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            int sourceCount = source.Count;
            for (int i = 0; i < sourceCount; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}