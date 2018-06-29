using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    using System.Collections;

    /// <summary>
    /// TODO: Warning, these say IList but are not pre-materialized, may need to note that somehow
    /// so developers do not expect
    /// 
    /// for (int i = 0; i lt 999999; i++)
    ///   DoStuff(result[0])
    ///   
    /// to be fast.
    /// 
    /// As today they have IEnumerable, not a problem until post-transition
    /// TODO: If we override (almost) all methods, including those of BCL that handle IList,
    /// we can move to a custom type and not expose IList
    /// </summary>
    public static partial class FastLinq
    {
        public static IReadOnlyList<TOut> Select<T, TOut>(
            this IReadOnlyList<T> source,
            Func<T, TOut> projection)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (projection == null)
            {
                throw new ArgumentNullException(nameof(projection));
            }

            return new SelectList<T, TOut>(
                source,
                projection);
        }

        public static IReadOnlyList<TOut> Select<T, TOut>(
            this IReadOnlyList<T> source,
            Func<T, int, TOut> projection)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (projection == null)
            {
                throw new ArgumentNullException(nameof(projection));
            }

            return new SelectWithIndexList<T, TOut>(
                source,
                projection);
        }

        private sealed class SelectList<T, TOut> : IReadOnlyList<TOut>, ICanCopyTo<TOut>
        {
            private readonly IReadOnlyList<T> list;
            private readonly Func<T, TOut> conversionFunc;

            public void CopyTo(long sourceIndex, TOut[] dest, long count)
            {
                for (int i = (int) sourceIndex; i < count; i++)
                {
                    var val = this.list[i];
                    dest[i] = this.conversionFunc(val);
                }
            }

            public SelectList(IReadOnlyList<T> list, Func<T, TOut> conversionFunc)
            {
                this.list = list;
                this.conversionFunc = conversionFunc;
            }

            public IEnumerator<TOut> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<TOut> GetEnumerable()
            {
                int listCount = this.list.Count;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    yield return this.conversionFunc(val);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            
            public int Count => this.list.Count;

            public TOut this[int index]
            {
                get
                {
                    var val = this.list[index];
                    var converted = this.conversionFunc(val);
                    return converted;
                }
            }
        }


        /// <summary>
        /// Copied from <see cref="SelectList{T,TOut}"/>
        /// </summary>
        private sealed class SelectWithIndexList<T, TOut> : IReadOnlyList<TOut>
        {
            private readonly IReadOnlyList<T> list;
            private readonly Func<T, int, TOut> conversionFunc;

            public SelectWithIndexList(IReadOnlyList<T> list, Func<T, int, TOut> conversionFunc)
            {
                this.list = list;
                this.conversionFunc = conversionFunc;
            }

            public IEnumerator<TOut> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<TOut> GetEnumerable()
            {
                int listCount = this.list.Count;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    yield return this.conversionFunc(val, i);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            
            public int Count => this.list.Count;
            public TOut this[int index]
            {
                get
                {
                    var val = this.list[index];
                    var converted = this.conversionFunc(val, index);
                    return converted;
                }
            }
        }
    }
}
