
namespace System.Linq {
    internal interface ICanCopyTo<in T>
    {
        void CopyTo(long sourceIndex, T[] dest, long count);
    }
}