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
        public static IList<TOut> Select<T, TOut>(
            this IList<T> source,
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

        public static IList<TOut> Select<T, TOut>(
            this IList<T> source,
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

        private sealed class SelectList<T, TOut> : IList<TOut>
        {
            private readonly IList<T> list;
            private readonly Func<T, TOut> conversionFunc;

            public SelectList(IList<T> list, Func<T, TOut> conversionFunc)
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

            void ICollection<TOut>.Add(TOut item)
            {
                throw new NotSupportedException();
            }

            void ICollection<TOut>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(TOut item)
            {
                int listCount = this.list.Count;
                var comparer = EqualityComparer<TOut>.Default;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val);
                    if (comparer.Equals(converted, item))
                    {
                        return true;
                    }
                }

                return false;
            }

            public void CopyTo(TOut[] array, int arrayIndex)
            {
                if (this.Count == 0)
                {
                    return;
                }

                if (array.Length < this.Count + arrayIndex)
                {
                    throw new ArgumentException("Destination array was not long enough. Check destIndex and length, and the array's lower bounds.");
                }

                int listCount = this.list.Count;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val);
                    array[arrayIndex + i] = converted;
                }
            }

            bool ICollection<TOut>.Remove(TOut item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.list.Count;
            public bool IsReadOnly => true;
            public int IndexOf(TOut item)
            {
                int listCount = this.list.Count;
                var comparer = EqualityComparer<TOut>.Default;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val);
                    if (comparer.Equals(converted, item))
                    {
                        return i;
                    }
                }

                return -1;
            }

            void IList<TOut>.Insert(int index, TOut item)
            {
                throw new NotSupportedException();
            }

            void IList<TOut>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public TOut this[int index]
            {
                get
                {
                    var val = this.list[index];
                    var converted = this.conversionFunc(val);
                    return converted;
                }

                set => throw new NotSupportedException();
            }
        }


        /// <summary>
        /// Copied from <see cref="SelectList{T,TOut}"/>
        /// </summary>
        private sealed class SelectWithIndexList<T, TOut> : IList<TOut>
        {
            private readonly IList<T> list;
            private readonly Func<T, int, TOut> conversionFunc;

            public SelectWithIndexList(IList<T> list, Func<T, int, TOut> conversionFunc)
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

            void ICollection<TOut>.Add(TOut item)
            {
                throw new NotSupportedException();
            }

            void ICollection<TOut>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(TOut item)
            {
                int listCount = this.list.Count;
                var comparer = EqualityComparer<TOut>.Default;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val, i);
                    if (comparer.Equals(converted, item))
                    {
                        return true;
                    }
                }

                return false;
            }

            public void CopyTo(TOut[] array, int arrayIndex)
            {
                if (this.Count == 0)
                {
                    return;
                }

                if (array.Length < this.Count + arrayIndex)
                {
                    throw new ArgumentException("Destination array was not long enough. Check destIndex and length, and the array's lower bounds.");
                }

                int listCount = this.list.Count;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val, i);
                    array[arrayIndex + i] = converted;
                }
            }

            public bool Remove(TOut item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.list.Count;
            public bool IsReadOnly => true;
            public int IndexOf(TOut item)
            {
                int listCount = this.list.Count;
                var comparer = EqualityComparer<TOut>.Default;
                for (int i = 0; i < listCount; i++)
                {
                    var val = this.list[i];
                    var converted = this.conversionFunc(val, i);
                    if (comparer.Equals(converted, item))
                    {
                        return i;
                    }
                }

                return -1;
            }

            void IList<TOut>.Insert(int index, TOut item)
            {
                throw new NotSupportedException();
            }

            void IList<TOut>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public TOut this[int index]
            {
                get
                {
                    var val = this.list[index];
                    var converted = this.conversionFunc(val, index);
                    return converted;
                }

                set => throw new NotSupportedException();
            }
        }
    }
}
