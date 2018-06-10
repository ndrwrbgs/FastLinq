namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IReadOnlyCollection<TResult> Cast<TSource, TResult>(
            this IReadOnlyCollection<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new EnumerableWithCount<TResult>(
                Enumerable.Cast<TResult>(source),
                source.Count);
        }

        [Obsolete("Prefer Cast<T, TOther> whenever possible.", error: false)]
        public static IReadOnlyCollection<TResult> Cast<TResult>(
            this ICollection source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new EnumerableWithCount<TResult>(
                Enumerable.Cast<TResult>(source),
                source.Count);
        }
    }
}