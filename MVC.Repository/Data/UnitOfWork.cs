namespace MVC.Repository.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}