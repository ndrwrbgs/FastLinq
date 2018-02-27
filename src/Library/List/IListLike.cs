using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    using System.Collections;
    
    // TODO: Needed if we want to properly intercept .Cast() which is on the non-generic member.
    internal interface IListLike<T> : IList<T>, IList
    {
    }

    internal sealed class ListWrapper<T> : IListLike<T>
    {
        private readonly List<T> _listLikeImplementation;

        public ListWrapper()
        {
            this._listLikeImplementation = new List<T>();
        }

        public ListWrapper(int capacity)
        {
            this._listLikeImplementation = new List<T>(capacity);
        }

        public ListWrapper(IEnumerable<T> collection)
        {
            this._listLikeImplementation = new List<T>(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._listLikeImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this._listLikeImplementation).GetEnumerator();
        }

        public void Add(T item)
        {
            this._listLikeImplementation.Add(item);
        }

        public int Add(object value)
        {
            return ((IList) this._listLikeImplementation).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList) this._listLikeImplementation).Contains(value);
        }

        void IList.Clear()
        {
            this._listLikeImplementation.Clear();
        }

        public int IndexOf(object value)
        {
            return ((IList) this._listLikeImplementation).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList) this._listLikeImplementation).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList) this._listLikeImplementation).Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            this._listLikeImplementation.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get => ((IList) this._listLikeImplementation)[index];
            set => ((IList) this._listLikeImplementation)[index] = value;
        }

        bool IList.IsReadOnly => ((IList) this._listLikeImplementation).IsReadOnly;

        public bool IsFixedSize => ((IList) this._listLikeImplementation).IsFixedSize;

        void ICollection<T>.Clear()
        {
            this._listLikeImplementation.Clear();
        }

        public bool Contains(T item)
        {
            return this._listLikeImplementation.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this._listLikeImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return this._listLikeImplementation.Remove(item);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) this._listLikeImplementation).CopyTo(array, index);
        }

        int ICollection.Count => this._listLikeImplementation.Count;

        public object SyncRoot => ((ICollection) this._listLikeImplementation).SyncRoot;

        public bool IsSynchronized => ((ICollection) this._listLikeImplementation).IsSynchronized;

        int ICollection<T>.Count => this._listLikeImplementation.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)this._listLikeImplementation).IsReadOnly;

        public int IndexOf(T item)
        {
            return this._listLikeImplementation.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this._listLikeImplementation.Insert(index, item);
        }

        void IList<T>.RemoveAt(int index)
        {
            this._listLikeImplementation.RemoveAt(index);
        }

        public T this[int index]
        {
            get => this._listLikeImplementation[index];
            set => this._listLikeImplementation[index] = value;
        }
    }
}
