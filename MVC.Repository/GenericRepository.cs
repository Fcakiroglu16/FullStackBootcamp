using Microsoft.EntityFrameworkCore;

namespace MVC.Repository
{
    public class GenericRepository<T>(AppDbContext context):IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> _genericDbSet = context.Set<T>();


        public IQueryable<T> GetAll() => _genericDbSet.AsQueryable();

        public IQueryable<T> GetAllByPaging(int page, int pageSize) =>
            _genericDbSet.Skip((page - 1) * pageSize).Take(pageSize).AsQueryable();

        public IQueryable<T> Where(Func<T, bool> func) => _genericDbSet.Where(func).AsQueryable();

        public async Task<T?> GetById(int id) => await _genericDbSet.FindAsync(id);


        public void Update(T entity) => _genericDbSet.Update(entity);

        public void Delete(T entity) => _genericDbSet.Remove(entity);
    }
}