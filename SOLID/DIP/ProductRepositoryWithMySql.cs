using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    internal class ProductRepositoryWithMySql : IProductRepository
    {
        public List<string> GetProducts()
        {
            return ["ahmet mysql", "mehmet mysql"];
        }
    }
}