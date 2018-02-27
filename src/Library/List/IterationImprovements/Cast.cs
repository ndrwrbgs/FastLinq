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
        // TODO: cannot support int->double, for instance
        internal static IList<TOther> Cast<T, TOther>(
            this IList<T> source)
            where T : TOther
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CastList<TOther, T>(source);
        }

        public static IList<T> Cast<T>(
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
        private sealed class CastList<T, TInner> : IList<T>
            where TInner : T
        {
            private readonly IList<TInner> underlyingList;

            public CastList(IList<TInner> underlyingList)
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

            void ICollection<T>.Add(T item)
            {
                throw new NotSupportedException();
            }

            void ICollection<T>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(T item)
            {
                // Copied from List with casting - TODO: Copy from source directly
                var listSize = this.underlyingList.Count;

                if ((object)item == null)
                {
                    for (int index = 0; index < listSize; ++index)
                    {
                        if ((object)this.underlyingList[index] == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                for (int index = 0; index < listSize; ++index)
                {
                    TInner itemAtIndex = this.underlyingList[index];
                    T castItemAtIndex = (T)itemAtIndex;
                    if (equalityComparer.Equals(castItemAtIndex, item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                // TODO: Measure, faster to manually iterate and cast, or to use 2 Array.Copy like this?
                TInner[] innerArray = new TInner[this.underlyingList.Count];
                this.underlyingList.CopyTo(innerArray, 0);
                
                Array.Copy(innerArray, 0, array, arrayIndex, innerArray.Length);
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.underlyingList.Count;

            public bool IsReadOnly => true;

            public int IndexOf(T item)
            {
                // Cannot use List's IndexOf nor Array.IndexOf<T>
                for (int i = 0; i < this.Count; ++i)
                {
                    TInner itemAtIndex = this.underlyingList[i];
                    T castItemAtIndex = (T) itemAtIndex;
                    if (Equals(castItemAtIndex, item))
                    {
                        return i;
                    }
                }

                return -1;
            }

            void IList<T>.Insert(int index, T item)
            {
                throw new NotSupportedException();
            }

            void IList<T>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public T this[int index]
            {
                get
                {
                    if (index >= this.underlyingList.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return (T) this.underlyingList[index];
                }
                set => throw new NotSupportedException();
            }

            private IEnumerable<T> GetEnumerable()
            {
                for (int index = 0; index < this.underlyingList.Count; index++)
                {
                    yield return (T) this.underlyingList[index];
                }
            }
        }

        /// <summary>
        /// Copied from <see cref="System.Linq.FastLinq.CastList{T,TInner}"/>
        /// </summary>
        private sealed class CastList<T> : IList<T>
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

            void ICollection<T>.Add(T item)
            {
                throw new NotSupportedException();
            }

            void ICollection<T>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(T item)
            {
                // Copied from List with casting
                var listSize = this.underlyingList.Count;

                if ((object)item == null)
                {
                    for (int index = 0; index < listSize; ++index)
                    {
                        if ((object)this.underlyingList[index] == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                for (int index = 0; index < listSize; ++index)
                {
                    object itemAtIndex = this.underlyingList[index];
                    T castItemAtIndex = (T)itemAtIndex;
                    if (equalityComparer.Equals(castItemAtIndex, item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                // TODO: Measure, faster to manually iterate and cast, or to use 2 Array.Copy like this?
                object[] innerArray = new object[this.underlyingList.Count];
                this.underlyingList.CopyTo(innerArray, 0);

                Array.Copy(innerArray, 0, array, arrayIndex, innerArray.Length);
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.underlyingList.Count;

            public bool IsReadOnly => true;

            public int IndexOf(T item)
            {
                // Cannot use List's IndexOf nor Array.IndexOf<T>
                for (int i = 0; i < this.Count; ++i)
                {
                    object itemAtIndex = this.underlyingList[i];
                    T castItemAtIndex = (T)itemAtIndex;
                    if (Equals(castItemAtIndex, item))
                    {
                        return i;
                    }
                }

                return -1;
            }

            void IList<T>.Insert(int index, T item)
            {
                throw new NotSupportedException();
            }

            void IList<T>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

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