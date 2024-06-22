using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (string.IsNullOrWhiteSpace(value)) return false;
            return true;
        }
    }
}