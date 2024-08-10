namespace MVC.Repository.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>?> GetAllWithCategoryIdAsync(int categoryId);
    }
}