using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndArrays.App
{
    internal record Person(string Name, string Surname);


    internal record person2
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public person2()
        {
            var p1 = new Person("ahmet", "yıldız");
            var p2 = new Person("ahmet", "yıldız");

            if (p1 == p2)
            {
                Console.WriteLine("p1 and p2 are equal");
            }
            else
            {
                Console.WriteLine("p1 and p2 are not equal");
            }
        }
    }
}