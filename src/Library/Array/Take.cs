namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static partial class FastLinq
    {
        internal static ArraySkipTakeReverseList<T> Take<T>(
            this T[] source,
            int take)
        {
            return new ArraySkipTakeReverseList<T>(
                source,
                0,
                take,
                true);
        }

        internal static ArraySkipTakeReverseList<T> Take<T>(
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

        internal static ArraySkipTakeReverseListWithProjection<TIn, T> Take<TIn, T>(
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
    }
}
