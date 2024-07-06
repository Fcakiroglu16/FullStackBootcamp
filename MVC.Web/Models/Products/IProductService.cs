using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products;

public interface IProductService
{
    Task Create(ProductCreateWrapperModel model);
    ProductUpdateWrapperModel GetUpdateModel(int id);
    Task Update(ProductUpdateWrapperModel model);
    List<ProductViewModel> GetProducts();
    List<SelectModel> GetPublishDuration();
    void Delete(int id);

    Task<ProductCreateWrapperModel> LoadCreateWrapperModel();


    bool HasProduct(string name);
}