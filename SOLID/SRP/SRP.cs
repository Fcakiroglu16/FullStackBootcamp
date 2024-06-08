using System.Text.Json;

namespace SOLID.SRP;

public class ProductWriter
{
    public void WriteToFile(List<Product> products)
    {
        var textAsJson = JsonSerializer.Serialize(products);
        File.WriteAllText("product.json", textAsJson);
    }

    public void WriteToConsole(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id} Name: {product.Name}");
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }
}

public class ProductService(IProductRepository productRepository, IStockRepository stockRepository)
{
    //private readonly IProductRepository _productRepository;

    //public ProductService(IProductRepository productRepository)
    //{
    //    _productRepository = productRepository;
    //}


    public void Add(Product product)
    {
        product.Price = product.Price * 1.2m;
        product.Price = +100;

        stockRepository.Update();
        productRepository.Add(product);
    }

    public List<Product> GetProducts()
    {
        var productList = productRepository.GetProducts();

        foreach (var product in productList)
        {
            product.Price = product.Price * 100;
        }

        return productList;
    }
}