
namespace System.Linq {
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// TODO: We should not expose this class, but we can use it internally
    /// for things that have to iterate as optimization - e.g. Select
    /// can iterate with this faster iterator maintaining the speed of an Array
    /// (depending on which methods are called)
    /// </summary>
    internal struct ArraySkipTakeReverseListWithProjection<TIn, T> : IReadOnlyList<T>, ICanCopyTo<T>
    {
        internal readonly TIn[] array;
        internal int offset;
        internal int count;
        internal bool iterateForward;
        internal Func<TIn, T> projection;

        public ArraySkipTakeReverseListWithProjection(TIn[] array, int offset, int count, bool iterateForward, Func<TIn, T> projection)
        {
            this.array = array;
            this.offset = offset;
            this.count = count;
            this.iterateForward = iterateForward;
            this.projection = projection;
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
            private readonly bool iterateForward;
            private int index;
            private readonly int count;
            private readonly int offset;
            private readonly Func<TIn, T> projection;
            private readonly TIn[] array;

            public Enumerator(ArraySkipTakeReverseListWithProjection<TIn, T> arrayClass)
            {
                this.iterateForward = arrayClass.iterateForward;
                this.count = arrayClass.count;
                this.offset = arrayClass.offset;
                this.projection = arrayClass.projection;
                this.array = arrayClass.array;

                if (this.iterateForward)
                {
                    this.index = -1;
                }
                else
                {
                    this.index = arrayClass.count;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (this.iterateForward)
                {
                    return ++this.index < this.count;
                }
                else
                {
                    return --this.index >= this.offset;
                }
            }

            public void Reset()
            {
                if (this.iterateForward)
                {
                    this.index = -1;
                }
                else
                {
                    this.index = this.count;
                }
            }

            public T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return this.projection.Invoke(
                        this.array[this.index]);
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }
        }

        public int Count => this.count;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (this.iterateForward)
                {
                    return this.projection(this.array[
                                               this.offset + index]);
                }
                else
                {
                    return this.projection(this.array[
                                               this.offset + this.count - 1 - index]);
                }
            }
        }

        public void CopyTo(long sourceIndex, T[] dest, long count)
        {
            for (int i = (int)sourceIndex; i < Math.Min(this.Count, count); i++)
            {
                dest[i] = this[i];
            }
        }
    }
}