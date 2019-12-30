namespace System.Linq
{
    public static partial class FastLinq
    {
        internal static ArraySkipTakeReverseList<T> Skip<T>(
            this T[] source,
            int skip)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            skip = Math.Max(0, skip);

            int count = source.Length - skip;

            return new ArraySkipTakeReverseList<T>(
                source,
                // TODO: Bounds check
                skip,
                count,
                true);
        }

        internal static ArraySkipTakeReverseList<T> Skip<T>(
            this ArraySkipTakeReverseList<T> array,
            int skip)
        {
            if (array.iterateForward)
            {
                // **[--->]*
                // **[|-->]*
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    skip,
                    array.Count - skip,
                    array.iterateForward);
            }
            else
            {
                // **[<---]*
                // **[<--|]*
                return new ArraySkipTakeReverseList<T>(
                    array.array,
                    array.offset,
                    array.count - skip,
                    array.iterateForward);
            }
        }
    }
}