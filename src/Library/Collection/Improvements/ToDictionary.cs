namespace System.Linq
{
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        /// <remarks>
        /// BCL does not set initial size
        /// </remarks>
        /// TODO: Should have array pooling but probably doesn't belong in this library
        /// TODO: Could have a lazy dictionary that memoizes as necessary but can optimize
        ///       for enumeration and the return types of Dictionary versus IDictionary
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this ICollection<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            var dictionary = new Dictionary<TKey, TSource>(source.Count);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                dictionary.Add(key, item);
            }

            return dictionary;
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this ICollection<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            var dictionary = new Dictionary<TKey, TSource>(source.Count, keyComparer);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                dictionary.Add(key, item);
            }

            return dictionary;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this ICollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> itemSelector,
            IEqualityComparer<TKey> keyComparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (itemSelector == null)
            {
                throw new ArgumentNullException(nameof(itemSelector));
            }

            var dictionary = new Dictionary<TKey, TElement>(source.Count, keyComparer);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                var value = itemSelector(item);
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this ICollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> itemSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (itemSelector == null)
            {
                throw new ArgumentNullException(nameof(itemSelector));
            }

            var dictionary = new Dictionary<TKey, TElement>(source.Count);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                var value = itemSelector(item);
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
}