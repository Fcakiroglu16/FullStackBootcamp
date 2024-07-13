using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllByPaging(int page, int pageSize);
        IQueryable<T> Where(Func<T, bool> func);
        Task<T?> GetById(int id);
        void Update(T entity);

        void Delete(T entity);

        Task Create(T entity);

        bool Any(Func<T, bool> func);
    }
}