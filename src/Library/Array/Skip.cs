namespace System.Linq
{
    public static partial class FastLinq
    {
        public static ArraySkipTakeReverseList<T> Skip<T>(
            this T[] source,
            int skip)
        {
            return new ArraySkipTakeReverseList<T>(
                source,
                // TODO: Bounds check
                skip,
                source.Length - skip,
                true);
        }

        public static ArraySkipTakeReverseList<T> Skip<T>(
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