using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCoding.App
{
    internal class Product
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }


        public Product()
        {
        }

        // static fatory method
        public static Product Create(int id, string name, decimal price)
        {
            return new Product() { Id = id, Name = name, Price = price };
        }
    }
}