namespace System.Linq
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static partial class FastLinq
    {
        // TODO: Tests and perf
        internal static IReadOnlyList<T> AsReadOnly<T>(
            this IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is IReadOnlyList<T> readOnly)
            {
                return readOnly;
            }

            return new ReadOnlyCollection<T>(source);
        }
    }
}
