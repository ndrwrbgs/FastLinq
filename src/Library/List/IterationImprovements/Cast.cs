namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Warning, these say IList but are not pre-materialized, may need to note that somehow
    /// so developers do not expect
    /// 
    /// for (int i = 0; i lt 999999; i++)
    ///   DoStuff(result[0])
    ///   
    /// to be fast
    /// </summary>
    public static partial class FastLinq
    {
        /// <summary>
        /// TODO: More accurate to expose IReadOnlyList, but then need to support that as input. Do later
        /// </summary>

        // Unless we want to expose IList from the types, we have
        // to have two type arguments here :(
        internal static IReadOnlyList<TOther> Cast<T, TOther>(
            this IReadOnlyList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CastList<TOther, T>(source);
        }

        public static IReadOnlyList<T> Cast<T>(
            this IList source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CastList<T>(source);
        }

        /// <summary>
        /// Interfaces copied from List
        /// </summary>
        private sealed class CastList<T, TInner> : IReadOnlyList<T>
        {
            private readonly IReadOnlyList<TInner> underlyingList;

            public CastList(IReadOnlyList<TInner> underlyingList)
            {
                this.underlyingList = underlyingList;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }
            
            public int Count => this.underlyingList.Count;
            
            public T this[int index]
            {
                get
                {
                    if (index >= this.underlyingList.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    dynamic underlying = this.underlyingList[index];
                    return (T) underlying;
                }
            }

            private IEnumerable<T> GetEnumerable()
            {
                for (int index = 0; index < this.underlyingList.Count; index++)
                {
                    dynamic underlying = this.underlyingList[index];
                    yield return (T) underlying;
                }
            }
        }

        /// <summary>
        /// Copied from <see cref="System.Linq.FastLinq.CastList{T,TInner}"/>
        /// </summary>
        private sealed class CastList<T> : IReadOnlyList<T>
        {
            private readonly IList underlyingList;

            public CastList(IList underlyingList)
            {
                this.underlyingList = underlyingList;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }
            
            public int Count => this.underlyingList.Count;
            
            public T this[int index]
            {
                get
                {
                    if (index >= this.underlyingList.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return (T)this.underlyingList[index];
                }
                set => throw new NotSupportedException();
            }
            
            private IEnumerable<T> GetEnumerable()
            {
                for (int index = 0; index < this.underlyingList.Count; index++)
                {
                    yield return (T)this.underlyingList[index];
                }
            }
        }
    }
}