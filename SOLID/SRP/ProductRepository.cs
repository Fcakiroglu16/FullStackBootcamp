namespace SOLID.SRP
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(string a)
        {
        }

        public ProductRepository(string a, string b)
        {
        }


        public List<Product> Products { get; set; } = new();


        public void Add(Product product)
        {
            Products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public void Remove(Product product)
        {
            Products.Remove(product);
        }
    }


    public interface IProductWriter
    {
    }

    public interface IProductHelper
    {
    }

    public interface IStockRepository
    {
        void Update();
    }

    public interface IProductRepository : IProductWriter, IProductHelper
    {
        void Add(Product product);

        decimal Calculate(int tax, decimal price)
        {
            return price * tax;
        }

        List<Product> GetProducts();

        void Remove(Product product);
    }
}