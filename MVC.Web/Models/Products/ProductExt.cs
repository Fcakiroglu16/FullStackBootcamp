using MVC.Web.Models.Products.ViewModels;

namespace MVC.Web.Models.Products
{
    public static class ProductExt
    {
        public static Product MapToProduct(this ProductCreateWrapperModel model, string pictureUrl, int id)
        {
            return new Product
            {
                Id = id,
                Name = model.ProductViewModel.Name,
                Price = model.ProductViewModel.Price!.Value,
                StockCount = model.ProductViewModel.StockCount,
                Description = model.ProductViewModel.Description,
                CategoryId = model.CategoryViewModel.CategoryId!.Value,
                PictureUrl = pictureUrl,
                IsPublisher = model.ProductViewModel.IsPublish,
                PublisherDurationId = model.ProductViewModel.IsPublisherDurationId!.Value,
                PublishExpire = model.ProductViewModel.PublishExpire!.Value
            };
        }


        public static Product MapToProduct(this ProductUpdateWrapperModel model, string? pictureUrl)
        {
            return new Product
            {
                Id = model.ProductViewModel.Id,
                Name = model.ProductViewModel.Name,
                Price = model.ProductViewModel.Price!.Value,
                StockCount = model.ProductViewModel.StockCount,
                Description = model.ProductViewModel.Description,
                CategoryId = model.CategoryViewModel.CategoryId,
                PictureUrl = pictureUrl,
                IsPublisher = model.ProductViewModel.IsPublish,
                PublisherDurationId = model.ProductViewModel.IsPublisherDurationId!.Value
            };
        }
    }
}