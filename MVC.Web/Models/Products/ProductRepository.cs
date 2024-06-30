namespace MVC.Web.Models.Products
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        private static List<Product> ProductList { get; set; } = new();


        //crud methods
        public void Add(Product product)
        {
            ProductList.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdate = ProductList.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.StockCount = product.StockCount;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public void Delete(int id)
        {
            var productToDelete = ProductList.FirstOrDefault(x => x.Id == id);
            if (productToDelete != null)
            {
                ProductList.Remove(productToDelete);
            }
        }

        public List<Product> GetAll()
        {
            return ProductList;
        }
    }
}