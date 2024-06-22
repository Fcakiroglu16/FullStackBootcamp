using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal static class SeoExtensions
    {
        public static string ShortUrl(this string url)
        {
            url = url.Replace("ö", "o");

            return url.Substring(0, 10);
        }
    }
}