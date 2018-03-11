namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Is it possible to optimize by allowing the Enumerator to be a generic to allow structs?
    /// Or do we have to have a specific type for each to support List/other classes that have optimized struct enumerators?
    /// </summary>
    internal struct EnumerableWithCount<T>
        : IReadOnlyCollection<T>
    {
        /// <summary>
        /// TODO: Potential improvement: contain an IEnumerable&ICollection, or expose only interface from methods
        /// and have multiple impl types
        /// </summary>
        private readonly IEnumerable<T> enumerable;

        public EnumerableWithCount(IEnumerable<T> enumerable, int count)
            : this()
        {
            this.enumerable = enumerable;
            this.count = count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // TODO: Multiple enumeration
            return this.enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private readonly int count;

        int IReadOnlyCollection<T>.Count => this.count;
    }
}