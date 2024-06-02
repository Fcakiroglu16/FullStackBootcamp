using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App2
{
    internal class A
    {
        public string Name { get; set; }
        public string SurName { get; set; }


        public void Method()
        {
            var b = new B();
            var fullName = b.FullName(this);

            Console.WriteLine(fullName);
        }
    }
}