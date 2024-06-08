using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    public interface IProductRepository
    {
        List<string> GetProducts();
    }


    internal class ProductRepositoryWithSql : IProductRepository
    {
        public void Calculate()
        {
        }

        public List<string> GetProducts()
        {
            return new List<string>() { "ahmet sql", "mehmet sql", "hasan sql" };
            return ["ahmet", "mehmet", "hasan"];
        }
    }
}