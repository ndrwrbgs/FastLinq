namespace System.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static partial class FastLinq
    {
        public static T[] ToArray<T>(
            this ArraySkipTakeReverseList<T> array)
        {
            var t = new T[array.Count];
            array.CopyTo(0, t, array.Count);
            return t;
        }
    }
}
