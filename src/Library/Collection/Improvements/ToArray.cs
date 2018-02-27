namespace System.Linq
{
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        /// <remarks>
        /// BCL does new Buffer(source).ToArray() and it's .ToArray()
        /// copies the Buffer's internal array instead of returning. This impl halves that cost.
        /// </remarks>
        /// TODO: Should have array pooling but probably doesn't belong in this library
        public static TSource[] ToArray<TSource>(
            this ICollection<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var array = new TSource[source.Count];
            source.CopyTo(array, 0);
            return array;
        }
    }
}