namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static partial class FastLinq
    {
        internal static ArraySkipTakeReverseList<T> Reverse<T>(
            this T[] source)
        {
            if (source == null)
            {
                // Cannot inline with this here
                throw new ArgumentNullException(nameof(source));
            }

            return new ArraySkipTakeReverseList<T>(
                source,
                0,
                source.Length,
                false);
        }

        internal static ArraySkipTakeReverseList<T> Reverse<T>(
            this ArraySkipTakeReverseList<T> source)
        {
            return new ArraySkipTakeReverseList<T>(
                source.array,
                source.offset,
                source.count,
                !source.iterateForward);
        }


        internal static ArraySkipTakeReverseListWithProjection<TIn, T> Reverse<TIn, T>(
            this ArraySkipTakeReverseListWithProjection<TIn, T> source)
        {
            return new ArraySkipTakeReverseListWithProjection<TIn, T>(
                source.array,
                source.offset,
                source.count,
                !source.iterateForward,
                source.projection);
        }
    }
}
