namespace System.Linq
{
    using System.Collections.Generic;

    public static partial class FastLinq
    {
        /// <summary>
        /// Casts with the knowledge that the result will be utilized in full.
        /// This allows the cast to be optimized
        /// </summary>
        public static TResult[] EagerCast<TSource, TResult>(
            this IReadOnlyList<TSource> source)
        {
            // Each cast allocates memory which takes time. We can, however, allocate it all up front
            // TODO: Should probably avoid this allocation if TSource can't be cast to TResult
            TResult[] results = new TResult[source.Count];
            object intermediate;
            for (int i = 0; i < source.Count; i++)
            {
                intermediate = source[i];
                results[i] = (TResult) intermediate;
            }

            return results;
        }
    }
}