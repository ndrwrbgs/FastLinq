namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        /// <summary>
        /// TODO: More accurate to expose IReadOnlyCollection, but then need to support that as input. Do later
        /// TODO: Update T references, update documentation, update param names
        /// </summary>
        public static ICollection<TSource> Concat<TSource>(
            this ICollection<TSource> source,
            ICollection<TSource> other)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return new EnumerableWithCount<TSource>(
                Enumerable.Concat(source, other),
                source.Count + other.Count);
        }
    }
}