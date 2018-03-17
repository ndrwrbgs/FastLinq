namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static List<T> ToList<T>(
            this IReadOnlyCollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var list = new List<T>(source.Count);
            foreach (var item in source)
            {
                list.Add(item);
            }

            return list;
        }
    }
}