using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App.OOPConcepts.Abstraction
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    internal interface IWriteProductRepository
    {
        int Create(Product product);

        void Update(Product product);

        void Delete(int id);
    }

    internal interface IReadProductRepository
    {
        Product GetById(int id);

        List<Product> GetAll();
    }


    internal class WriteProductRepositoryWithSqlServer : IWriteProductRepository
    {
        public int A { get; set; }

        public void method()
        {
        }


        public int Create(Product product)
        {
            //  save to db
            return 1;
        }

        public void Update(Product product)
        {
            //  save to db
        }

        public void Delete(int id)
        {
            //  save to db
        }
    }


    internal class ReadProductRepositoryWithSqlSever : IReadProductRepository
    {
        public Product GetById(int id)
        {
            return new Product();
        }

        public List<Product> GetAll()
        {
            return new List<Product>();
        }
    }
}