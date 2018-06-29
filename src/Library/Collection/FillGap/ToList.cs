namespace System.Linq
{
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        /// <remarks>
        /// Needed mostly for parity, so that the <see cref="IReadOnlyCollection{T}"/> types that are returned by this library
        /// can be .ToList'd efficiently even when they are not <see cref="ICollection{T}"/>s
        /// </remarks>
        public static List<T> ToList<T>(
            this IReadOnlyCollection<T> source)
        {
            if (source is ICollection<T>)
            {
                return new List<T>(source);
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Use ToArray method and then insert it into the List
            //var c = source.ToArray();

            var list = new List<T>(source.Count);
            foreach (var item in source)
            {
                list.Add(item);
            }

            return list;
        }
    }
}