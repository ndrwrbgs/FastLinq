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
        /// TODO: We cannot expose both IReadOnlyCollection and ICollection without ambiguity
        ///   meaning we can't intercept calls to our exposed metods if we expose this one.
        ///   perhaps we leave this one up to the implementor and stay in our model? Not sure...
        public static TSource[] ToArray<TSource>(
            this IReadOnlyCollection<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is ICanCopyTo<TSource> c)
            {
                var t = new TSource[source.Count];
                c.CopyTo(0, t, source.Count);
                return t;
            }

            else if (source is ICollection<TSource> t)
            {
                var array = new TSource[source.Count];
                t.CopyTo(array, 0);
                return array;
            }
            else
            {
                return Enumerable.ToArray(source);
            }
        }
    }
}