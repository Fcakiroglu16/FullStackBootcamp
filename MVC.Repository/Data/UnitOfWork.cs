namespace MVC.Repository
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}