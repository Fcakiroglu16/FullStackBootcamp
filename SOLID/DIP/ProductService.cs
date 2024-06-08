using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    internal class ProductService(IProductRepository productRepository)
    {
        public List<string> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public List<string> GetProducts2()
        {
            var productRepository = new ProductRepositoryWithOracle();

            return productRepository.GetProducts();
        }
    }
}