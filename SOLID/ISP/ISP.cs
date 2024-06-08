using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.SRP;

namespace SOLID.ISP
{
    public interface IProductRepository
    {
    }

    public interface IReadRepository
    {
        Product Read(int id);
    }

    public interface ICModuleProductRepository
    {
        Product Read(int id);
        void Delete(int id);
    }

    public interface IWriteProductRepository
    {
        void Create(Product product);

        void Update(Product product);
        void Delete(int id);
    }


    public class ProductRepository : IReadRepository, IWriteProductRepository, ICModuleProductRepository
    {
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}