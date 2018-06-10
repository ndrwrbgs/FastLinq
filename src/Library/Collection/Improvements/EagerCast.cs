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
            this IReadOnlyCollection<TSource> source)
        {
            // Each cast allocates memory which takes time. We can, however, allocate it all up front
            // TODO: Should probably avoid this allocation if TSource can't be cast to TResult
            TResult[] results = new TResult[source.Count];
            object intermediate;
            int index = 0;
            foreach (var item in source)
            {
                intermediate = item;
                results[index] = (TResult) intermediate;
                index++;
            }

            return results;
        }
    }
}