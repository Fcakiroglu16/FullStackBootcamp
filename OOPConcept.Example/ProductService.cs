using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept.Example
{
    internal class ProductService(IProductRepository _productRepository)
    {
        //private readonly IProductRepository _productRepository;

        //public ProductService(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public List<Product> GetProducts() => _productRepository.GetProducts();

        public int Save(Product newProduct)
        {
            if (_productRepository.Any(_productRepository.GetNewId()))
            {
                throw new Exception($"Ürün id({newProduct.Id})'si db'de bulunmaktadır.");
            }


            var newProductId = _productRepository.Save(newProduct);

            return newProductId;
        }

        public decimal CalculateTax(int tax, int rate, decimal price)
        {
            // SqlConnection connection= new SqlConnection("connectionString");
            // connection.Open();
            // SqlCommand command = new SqlCommand("Select * from Tax", connection);
            // SqlDataReader reader = command.ExecuteReader();


            var productHelper = new ProductHelper();
            FileStream file;


            var newTax = tax / rate;


            return price * newTax;


            return 0;
        }
    }
}