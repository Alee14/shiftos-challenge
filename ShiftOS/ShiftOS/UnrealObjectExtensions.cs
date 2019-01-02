using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftOS
{
    /// <summary>
    /// Contains extension methods to add features to C# objects that Unreal Engine 4 has baked in.
    /// </summary>
    public static class UnrealObjectExtensions
    {
        public static bool IsA<T>(this object InObject)
        {
            return InObject is T;
        }
    }
}
