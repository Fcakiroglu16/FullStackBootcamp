using Microsoft.EntityFrameworkCore;
using MVC.Repository.Data;

namespace MVC.Repository
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> _genericDbSet = context.Set<T>();


        public IQueryable<T> GetAll() => _genericDbSet.AsNoTracking().AsQueryable();

        public IQueryable<T> GetAllByPaging(int page, int pageSize) =>
            _genericDbSet.Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().AsQueryable();

        public IQueryable<T> Where(Func<T, bool> func) => _genericDbSet.AsNoTracking().Where(func).AsQueryable();

        public bool Any(Func<T, bool> func) => _genericDbSet.AsNoTracking().Any(func);

        public async Task<T?> GetById(int id) => await _genericDbSet.FindAsync(id);


        public void Update(T entity) => _genericDbSet.Update(entity);

        public void Delete(T entity) => _genericDbSet.Remove(entity);

        public async Task Create(T entity)
        {
            await _genericDbSet.AddAsync(entity);
        }
    }
}