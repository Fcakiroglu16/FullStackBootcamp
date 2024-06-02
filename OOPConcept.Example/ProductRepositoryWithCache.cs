using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept.Example
{
    internal class ProductRepositoryWithCache : IProductRepository
    {
        public int Save(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public bool Any(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}