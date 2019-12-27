
namespace System.Linq {
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal static class CanCopyHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTo<T>(
            IReadOnlyList<T> source,
            long sourceIndex, T[] dest, long count)
        {
            if (source is ICanCopyTo<T> a)
            {
                a.CopyTo(sourceIndex, dest, count);
                return;
            }
            else if (source is T[] b)
            {
                Array.Copy(b, (int)sourceIndex, dest, 0, (int)count);
                return;
            }
            // TODO: Any other types?
            else if (source is List<T> c)
            {
                c.CopyTo((int)sourceIndex, dest, 0, (int)count);
                return;
            }
            else if (source is ICollection<T> d)
            {
                // TODO: Doesn't support sourceIndex
                if (sourceIndex == 0 && source.Count == count)
                {
                    d.CopyTo(dest, 0);
                    return;
                }
            }

            // TODO:
            throw new NotImplementedException("TODO");
        }
    }
}