using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq
{
    public static partial class FastLinq
    {
        internal interface ICanCopyTo<in T>
        {
            void CopyTo(long sourceIndex, T[] dest, long count);
        }

        private static class CanCopyHelper
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void CopyTo<T>(
                IReadOnlyList<T> source,
                long sourceIndex, T[] dest, long count)
            {
                if (source is ICanCopyTo<T> a)
                {
                    a.CopyTo(sourceIndex, dest, count);
                    return;
                }
                else if (source is T[] b)
                {
                    Array.Copy(b, (int) sourceIndex, dest, 0, (int) count);
                    return;
                }
                // TODO: Any other types?
                else if (source is List<T> c)
                {
                    c.CopyTo((int)sourceIndex, dest, 0, (int)count);
                    return;
                }
                else if (source is ICollection<T> d)
                {
                    // TODO: Doesn't support sourceIndex
                    if (sourceIndex == 0 && source.Count == count)
                    {
                        d.CopyTo(dest, 0);
                        return;
                    }
                }

                // TODO:
                throw new NotImplementedException("TODO");
            }
        }

        public static ArraySkipTakeReverseList<T> Take<T>(
            this T[] source,
            int take)
        {
            return new ArraySkipTakeReverseList<T>(
                source,
                0,
                take,
                true);
        }

        public static ArraySkipTakeReverseList<T> Take<T>(
            this ArraySkipTakeReverseList<T> array,
            int take)
        {
            var finalTake = Math.Min(array.count, take);
            if (array.iterateForward)
            {
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    array.offset,
                    finalTake,
                    array.iterateForward);
            }
            else
            {
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    array.offset + array.count - finalTake,
                    finalTake,
                    array.iterateForward);
            }
        }

        public static ArraySkipTakeReverseList<T> Skip<T>(
            this T[] source,
            int skip)
        {
            return new ArraySkipTakeReverseList<T>(
                source,
                // TODO: Bounds check
                skip,
                source.Length - skip,
                true);
        }

        public static ArraySkipTakeReverseList<T> Skip<T>(
            this ArraySkipTakeReverseList<T> array,
            int skip)
        {
            if (array.iterateForward)
            {
                // **[--->]*
                // **[|-->]*
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    skip,
                    array.Count - skip,
                    array.iterateForward);
            }
            else
            {
                // **[<---]*
                // **[<--|]*
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    array.offset,
                    array.count - skip,
                    array.iterateForward);
            }
        }

        public static ArraySkipTakeReverseList<T> Reverse<T>(
            this T[] source)
        {
            return new ArraySkipTakeReverseList<T>(
                source,
                0,
                source.Length,
                false);
        }

        public static ArraySkipTakeReverseList<T> Reverse<T>(
            this ArraySkipTakeReverseList<T> source)
        {
            return new ArraySkipTakeReverseList<T>(
                source.array,
                source.offset,
                source.count,
                !source.iterateForward);
        }

        public static T[] ToArray<T>(
            this ArraySkipTakeReverseList<T> array)
        {
            var t = new T[array.Count];
            array.CopyTo(0, t, array.Count);
            return t;
        }

        public static ArraySkipTakeReverseListWithProjection<TIn, T> Select<TIn, T>(
            this TIn[] source,
            Func<TIn, T> projection)
        {
            return new ArraySkipTakeReverseListWithProjection<TIn, T>(
                source,
                0,
                source.Length,
                true,
                projection);
        }

        public static ArraySkipTakeReverseListWithProjection<TIn, T> Select<TIn, T>(
            this ArraySkipTakeReverseList<TIn> source,
            Func<TIn, T> projection)
        {
            return new ArraySkipTakeReverseListWithProjection<TIn, T>(
                source.array,
                source.offset,
                source.count,
                source.iterateForward,
                projection);
        }

        public static ArraySkipTakeReverseListWithProjection<TIn, T> Take<TIn, T>(
            this ArraySkipTakeReverseListWithProjection<TIn, T> source,
            int take)
        {
            var finalTake = Math.Min(source.count, take);
            if (source.iterateForward)
            {
                return new ArraySkipTakeReverseListWithProjection<TIn, T>(
                    source.array,
                    source.offset,
                    finalTake,
                    source.iterateForward,
                    source.projection);
            }
            else
            {
                return new ArraySkipTakeReverseListWithProjection<TIn, T>(
                    source.array,
                    source.offset + source.count - finalTake,
                    finalTake,
                    source.iterateForward,
                    source.projection);
            }
        }

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

        /// <summary>
        /// TODO: We should not expose this class, but we can use it internally
        /// for things that have to iterate as optimization - e.g. Select
        /// can iterate with this faster iterator maintaining the speed of an Array
        /// (depending on which methods are called)
        /// </summary>
        public struct ArraySkipTakeReverseListWithProjection<TIn, T> : IReadOnlyList<T>, ICanCopyTo<T>
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
}