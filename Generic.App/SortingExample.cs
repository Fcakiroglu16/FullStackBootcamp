using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.App
{
    internal class SortingExample<T>
    {
        internal List<T> Sort(List<T> list)
        {
            return list.OrderBy(x => x).ToList();
        }
    }


    internal class SortingExample2<T, T2> where T : IEnumerable<T2>
    {
        internal List<T2> Sort(T list)
        {
            return list.OrderBy(x => x).ToList();
        }
    }

    internal class SortingExample4
    {
        internal List<T2> Sort<T, T2>(T list) where T : IEnumerable<T2>
        {
            return list.OrderBy(x => x).ToList();
        }
    }
}