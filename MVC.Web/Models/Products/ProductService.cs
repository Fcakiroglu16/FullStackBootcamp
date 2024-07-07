using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Web.Models.Categories;
using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products
{
    public class ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        : IProductService
    {
        public async Task Create(ProductCreateWrapperModel model)
        {
            var imageFile = model.ProductViewModel.ImageFile;

            var imageFileUrl = string.Empty;

            if (imageFile?.Length > 0)
            {
                var fileExtension = Path.GetExtension(imageFile.FileName); //.jpg .png

                imageFileUrl = $"{Guid.NewGuid().ToString()}{fileExtension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", imageFileUrl);


                await using var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }

            #region legacy code

            // MapHelper.MapToProduct(ProductCreateWrapperModel model)
            //model.MapToProduct
            //var product = new Product
            //{
            //    Id = new Random().Next(1, 10000),
            //    Name = model.ProductViewModel.Name,
            //    Price = model.ProductViewModel.Price,
            //    StockCount = model.ProductViewModel.StockCount,
            //    Description = model.ProductViewModel.Description,
            //    CategoryId = model.CategoryViewModel.CategoryId,
            //    PictureUrl = randomFileName,
            //    IsPublisher = model.ProductViewModel.IsPublish,
            //    PublisherDurationId = model.ProductViewModel.IsPublisherDurationId
            //}; 

            #endregion


            productRepository.Add(model.MapToProduct(imageFileUrl, new Random().Next(1, 10000)));
        }


        public async Task<ProductCreateWrapperModel> LoadCreateWrapperModel()
        {
            var productCreateWrapperModel = new ProductCreateWrapperModel();
            var categoryViewModelList = categoryRepository.GetAll();
            productCreateWrapperModel.CategoryViewModel.CategorySelectList =
                new SelectList(categoryViewModelList, "Id", "Name");

            productCreateWrapperModel.ProductViewModel =
                new ProductCreateViewModel(productRepository.GetPublishDuration());

            return productCreateWrapperModel;
        }

        public ProductUpdateWrapperModel GetUpdateModel(int id)
        {
            var wrapper = new ProductUpdateWrapperModel();


            var product = productRepository.GetById(id);


            wrapper.ProductViewModel = new ProductUpdateViewModel(productRepository.GetPublishDuration())
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount,
                Description = product.Description,
                IsPublish = product.IsPublisher,
                IsPublisherDurationId = product.PublisherDurationId,
                PictureUrl = product.PictureUrl
            };


            wrapper.CategoryViewModel.CategoryId = product.CategoryId;
            wrapper.CategoryViewModel.CategorySelectList = new SelectList(categoryRepository.GetAll(), "Id", "Name");

            return wrapper;
        }


        public async Task Update(ProductUpdateWrapperModel model)
        {
            var imageFile = model.ProductViewModel.ImageFile;

            var imageFileUrl = model.ProductViewModel.PictureUrl;

            if (imageFile?.Length > 0)
            {
                var fileExtension = Path.GetExtension(imageFile.FileName); //.jpg .png

                imageFileUrl = $"{Guid.NewGuid().ToString()}{fileExtension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", imageFileUrl);

                await using var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }


            #region legacy code

            //var product = new Product
            //{
            //    Id = model.ProductViewModel.Id,
            //    Name = model.ProductViewModel.Name,
            //    Price = model.ProductViewModel.Price,
            //    StockCount = model.ProductViewModel.StockCount,
            //    Description = model.ProductViewModel.Description,
            //    CategoryId = model.CategoryViewModel.CategoryId,
            //    PictureUrl = randomFileName,
            //    IsPublisher = model.ProductViewModel.IsPublish,
            //    PublisherDurationId = model.ProductViewModel.IsPublisherDurationId
            //}; 

            #endregion


            productRepository.Update(model.MapToProduct(imageFileUrl));
        }


        public List<ProductViewModel> GetProducts()
        {
            return productRepository.GetAll().Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockCount = x.StockCount,
                Description = x.Description,
                CategoryName = categoryRepository.GetById(x.CategoryId)!.Name,
                PictureUrl = x.PictureUrl,
                IsPublisher = x.IsPublisher,
                PublishDuration = productRepository.GetPublishDuration()
                    .First(y => y.Value == x.PublisherDurationId.ToString()).Text,
                PublishExpire = x.PublishExpire.ToLongDateString()
            }).ToList();
        }

        public List<SelectModel> GetPublishDuration() => productRepository.GetPublishDuration();

        public void Delete(int id) => productRepository.Delete(id);


        public bool HasProduct(string name)
        {
            return productRepository.HasProduct(x => x.Name == name);
        }

        public bool HasProduct(int id)
        {
            return productRepository.HasProduct(x => x.Id == id);
        }
    }
}