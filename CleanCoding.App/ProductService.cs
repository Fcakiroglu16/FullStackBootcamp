using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCoding.App
{
    internal class ProductService
    {
        public void CalculateTax(Product product)
        {
            //  product.Price = product.Price * 20;


            var newProduct =
                Product.Create(product.Id, product.Name,
                    product.Price *
                    20); //new Product() { Id = product.Id, Name = product.Name, Price = product.Price * 20 };
            // db / api
        }
    }
}