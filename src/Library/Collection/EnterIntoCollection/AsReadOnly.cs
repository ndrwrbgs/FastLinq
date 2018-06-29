namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static partial class FastLinq
    {
        // TODO: Tests and perf
        public static IReadOnlyCollection<T> AsReadOnly<T>(
            this ICollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is IReadOnlyCollection<T> readOnly)
            {
                return readOnly;
            }

            if (source is IList<T> list)
            {
                // No reason to lose the "is IList" information
                return new ReadOnlyCollection<T>(list);
            }

            return new CollectionBasedReadOnlyCollection<T>(source);
        }

        /// <summary>
        /// Because <see cref="ReadOnlyCollection{T}"/> is <see cref="IList{T}"/> based
        /// </summary>
        private sealed class CollectionBasedReadOnlyCollection<T> : IReadOnlyCollection<T>
        {
            private readonly ICollection<T> collection;

            public CollectionBasedReadOnlyCollection(ICollection<T> collection)
            {
                this.collection = collection;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.collection.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable) this.collection).GetEnumerator();
            }

            public int Count => this.collection.Count;
        }
    }
}
