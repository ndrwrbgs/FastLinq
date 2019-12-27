namespace System.Linq {
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: We should not expose this class, but we can use it internally
    /// for things that have to iterate as optimization - e.g. Select
    /// can iterate with this faster iterator maintaining the speed of an Array
    /// (depending on which methods are called)
    /// </summary>
    public struct ArraySkipTakeReverseList<T> : IReadOnlyList<T>, ICanCopyTo<T>
    {
        internal readonly T[] array;
        internal int offset;
        internal int count;
        internal bool iterateForward;

        public ArraySkipTakeReverseList(T[] array, int offset, int count, bool iterateForward)
        {
            this.array = array;
            this.offset = offset;
            this.count = count;
            this.iterateForward = iterateForward;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly ArraySkipTakeReverseList<T> arrayClass;
            private int index;

            public Enumerator(ArraySkipTakeReverseList<T> arrayClass)
            {
                this.arrayClass = arrayClass;
                this.index = -1;
            }

            public bool MoveNext()
            {
                return ++this.index < this.arrayClass.count;
            }

            public void Reset()
            {
                this.index = -1;
            }

            public T Current => this.arrayClass[this.index];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }
        }

        public int Count => this.count;

        public T this[int index]
        {
            get
            {
                if (this.iterateForward)
                {
                    return this.array[
                        this.offset + index];
                }
                else
                {
                    return this.array[
                        this.offset + this.count - 1 - index];
                }
            }
        }

        public void CopyTo(long sourceIndex, T[] dest, long count)
        {
            Array.Copy(
                this.array,
                this.offset + (int)sourceIndex,
                dest,
                0,
                Math.Min((int)count, this.count));
        }
    }
}