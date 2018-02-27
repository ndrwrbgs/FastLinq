using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    using System.Collections;

    public static partial class FastLinq
    {
        public static IList<T> Take<T>(
            this IList<T> source,
            int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new TakeList<T>(
                source,
                count);
        }

        private sealed class TakeList<T> : IList<T>
        {
            private static T[] Empty = new T[]{};

            private readonly IList<T> list;
            private readonly int take;

            public TakeList(IList<T> list, int take)
            {
                if (take < 0)
                {
                    // This is analogous to what the BCL does
                    take = 0;
                }

                if (take == 0)
                {
                    this.list = Empty;
                    this.take = 0;
                    return;
                }

                this.list = list;
                this.take = Math.Min(take, this.list.Count);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                for (int i = 0; i < this.take; i++)
                {
                    yield return this.list[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
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
                if ((object)item == null)
                {
                    for (int index = 0; index < this.take; ++index)
                    {
                        if ((object)this.list[index] == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                for (int index = 0; index < this.take; ++index)
                {
                    if (equalityComparer.Equals(this.list[index], item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                if (this.Count == 0)
                {
                    return;
                }

                if (array.Length < this.Count + arrayIndex)
                {
                    throw new ArgumentException("Destination array was not long enough. Check destIndex and length, and the array's lower bounds.");
                }

                // Can do better when done on List<T> or T[] instead of IList
                // TODO: If we overload those, remove the handling here below

                // TODO: What about special handling for all the IList types in this library, which underlying also
                // have T[] or List<T>, looking more and more like a custom type is needed to expose that property internally in the library
                if (this.list is T[])
                {
                    Array.Copy((T[]) this.list, 0, array, arrayIndex, this.take);
                }
                else if (this.list is List<T>)
                {
                    ((List<T>) this.list).CopyTo(0, array, arrayIndex, this.take);
                }
                else
                {
                    // TODO: Two options - ArrayCopy all of List and then copy a subset, or manually copy each item
                    // As copying twice would also involve allocating more memory, opting for the later for now. TODO: Document the decision later
                    for (int i = 0; i < this.take; i++)
                    {
                        array[arrayIndex + i] = this.list[i];
                    }
                }
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => Math.Min(this.list.Count, this.take);
            public bool IsReadOnly => true;
            public int IndexOf(T item)
            {
                // Not using this because it would require iterating the whole list, which isn't necessary
                ////var index = this.list.IndexOf(item);
                if (this.list is T[])
                {
                    // TODO: [nit] (T[]) cast or (Array) cast perf
                    return Array.IndexOf((T[]) this.list, item, 0, this.take);
                }
                else if (this.list is List<T>)
                {
                    return ((List<T>) this.list).IndexOf(item, 0, this.take);
                }
                else
                {
                    // TODO: I read something about optimizations to using DefaultEqualityComparer
                    // if so, we may need to update these Equals to use the comparer directly
                    // (the 'something' was mentioned in a commit in corefx source for Enumerable)
                    // Porting over from the .Contains method, where it was used in source today
                    EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                    for (int i = 0; i < this.take; ++i)
                    {
                        if (equalityComparer.Equals(this.list[i], item))
                        {
                            return i;
                        }
                    }

                    return -1;
                }
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
                    if (index >= this.Count
                        || index >= this.take)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.list[index];
                }

                set => throw new NotSupportedException();
            }
        }
    }
}
