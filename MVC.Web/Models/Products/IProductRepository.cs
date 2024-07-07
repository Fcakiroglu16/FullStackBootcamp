using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    List<Product> GetAll();
    Product? GetById(int id);
    string GetPublishDurationKey(string value);
    List<SelectModel> GetPublishDuration();

    bool HasProduct(string name);

    bool HasProduct(Func<Product, bool> func);
}