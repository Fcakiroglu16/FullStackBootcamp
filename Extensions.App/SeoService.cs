using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.App
{
    internal class SeoService
    {
        internal string ShortUrl(string url)
        {
            return url.Substring(0, 10);
        }
    }
}