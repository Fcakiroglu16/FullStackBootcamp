using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    internal class ProductRepositoryWithOracle : IProductRepository
    {
        public List<string> GetProducts()
        {
            return ["ahmet oracle", "mehmet oracle"];
        }
    }
}