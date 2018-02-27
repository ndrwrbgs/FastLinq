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
        public static IList<T> Skip<T>(
            this IList<T> source,
            int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new SkipList<T>(
                source,
                count);
        }

        private sealed class SkipList<T> : IList<T>
        {
            private static T[] Empty = new T[]{};

            private readonly IList<T> list;
            private readonly int skip;

            public SkipList(IList<T> list, int skip)
            {
                if (skip >= list.Count)
                {
                    this.list = Empty;
                    this.skip = 0;
                    return;
                }

                if (skip < 0)
                {
                    // Analogous to what the BCL does
                    skip = 0;
                }

                this.list = list;
                this.skip = skip;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return GetEnumerable().GetEnumerator();
            }

            private IEnumerable<T> GetEnumerable()
            {
                var listCount = this.list.Count;
                for (int i = skip; i < listCount; i++)
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
                var listCount = this.list.Count;
                if ((object)item == null)
                {
                    for (int index = this.skip; index < listCount; ++index)
                    {
                        if ((object)this.list[index] == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                for (int index = this.skip; index < listCount; ++index)
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
                    Array.Copy((T[]) this.list, this.skip, array, arrayIndex, this.list.Count - this.skip);
                }
                else if (this.list is List<T>)
                {
                    ((List<T>) this.list).CopyTo(this.skip, array, arrayIndex, this.list.Count - this.skip);
                }
                else
                {
                    // TODO: Two options - ArrayCopy all of List and then copy a subset, or manually copy each item
                    // As copying twice would also involve allocating more memory, opting for the later for now. TODO: Document the decision later
                    int listCount = this.list.Count;
                    for (int i = this.skip; i < listCount; i++)
                    {
                        array[arrayIndex + i - this.skip] = this.list[i];
                    }
                }
            }

            bool ICollection<T>.Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.list.Count - this.skip;
            public bool IsReadOnly => true;
            public int IndexOf(T item)
            {
                if (this.list is T[])
                {
                    // TODO: [nit] (T[]) cast or (Array) cast perf
                    int indexOf = Array.IndexOf((T[]) this.list, item, this.skip);
                    if (indexOf == -1)
                    {
                        return -1;
                    }
                    return indexOf - this.skip;
                }
                else if (this.list is List<T>)
                {
                    int indexOf = ((List<T>) this.list).IndexOf(item, this.skip);
                    if (indexOf == -1)
                    {
                        return -1;
                    }
                    return indexOf - this.skip;
                }
                else
                {
                    // TODO: I read something about optimizations to using DefaultEqualityComparer
                    // if so, we may need to update these Equals to use the comparer directly
                    // (the 'something' was mentioned in a commit in corefx source for Enumerable)
                    // Porting over from the .Contains method, where it was used in source today
                    EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
                    int count = this.list.Count;
                    for (int i = this.skip; i < count; ++i)
                    {
                        if (equalityComparer.Equals(this.list[i], item))
                        {
                            return i - this.skip;
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
                get => this.list[index + this.skip];

                set => throw new NotSupportedException();
            }
        }
    }
}
