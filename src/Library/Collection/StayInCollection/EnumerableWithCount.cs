namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Is it possible to optimize by allowing the Enumerator to be a generic to allow structs?
    /// Or do we have to have a specific type for each to support List/other classes that have optimized struct enumerators?
    /// </summary>
    internal struct EnumerableWithCount<T>
        // TODO: Possible usage optimization - avoid exposing ICollection which has write methods by fully intercepting calls once inside the framework.
        : ICollection<T>, IReadOnlyCollection<T>
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
            return this.enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            // TODO: Will this slow down in some cases?
            return this.enumerable.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (this.count == 0)
            {
                return;
            }

            if (array.Length < this.count + arrayIndex)
            {
                throw new ArgumentException("Destination array was not long enough. Check destIndex and length, and the array's lower bounds.");
            }

            // TODO: Definitely not optimal
            int i = 0;
            foreach (var item in this.enumerable)
            {
                array[arrayIndex + i++] = item;
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        private readonly int count;

        int ICollection<T>.Count => this.count;

        public bool IsReadOnly => true;

        int IReadOnlyCollection<T>.Count => this.count;
    }
}