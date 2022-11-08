using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<(T, int)> EnumerateWithIndex<T>(this IEnumerable<T> list)
        {
            return list.Select((x, i) => (x, i));
        }
    }
}
