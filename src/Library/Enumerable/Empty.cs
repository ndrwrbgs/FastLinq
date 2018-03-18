namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    
    public static partial class FastLinq
    {
        public static IReadOnlyList<T> Empty<T>()
        {
            return new T[] { };
        }
    }
}