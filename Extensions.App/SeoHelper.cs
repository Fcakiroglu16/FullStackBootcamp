using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal class SeoHelper
    {
        internal static string ShortUrl(string url)
        {
            return url.Substring(0, 10);
        }
    }
}