namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static partial class FastLinq
    {

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

    }
}
