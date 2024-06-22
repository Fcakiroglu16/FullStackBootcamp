using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal static class ListExtensions
    {
        internal static ICollection<int> GetRandomList(this ICollection<int> list)
        {
            return list.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}