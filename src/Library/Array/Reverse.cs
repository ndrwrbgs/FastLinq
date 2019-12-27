namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static partial class FastLinq
    {
        public static ArraySkipTakeReverseList<T> Reverse<T>(
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

        public static ArraySkipTakeReverseList<T> Reverse<T>(
            this ArraySkipTakeReverseList<T> source)
        {
            return new ArraySkipTakeReverseList<T>(
                source.array,
                source.offset,
                source.count,
                !source.iterateForward);
        }


        public static ArraySkipTakeReverseListWithProjection<TIn, T> Reverse<TIn, T>(
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
