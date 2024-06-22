using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal static class NumberExtensions
    {
        internal static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
    }
}