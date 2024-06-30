using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Web.Models.Categories;
using MVC.Web.Models.Products.ViewModels;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products
{
    public class ProductService
    {
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
        }


        public async Task Create(ProductCreateWrapperModel model)
        {
            var imageFile = model.ProductViewModel.ImageFile;

            var randomFileName = string.Empty;

            if (imageFile is not null && imageFile.Length > 0)
            {
                var fileExtension = Path.GetExtension(imageFile.FileName); //.jpg .png

                randomFileName = $"{Guid.NewGuid().ToString()}{fileExtension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", randomFileName);


                await using var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }


            var product = new Product
            {
                Id = new Random().Next(1, 10000),
                Name = model.ProductViewModel.Name,
                Price = model.ProductViewModel.Price,
                StockCount = model.ProductViewModel.StockCount,
                Description = model.ProductViewModel.Description,
                CategoryId = model.CategoryViewModel.CategoryId,
                PictureUrl = randomFileName,
                IsPublisher = model.ProductViewModel.IsPublish,
                PublisherDurationId = model.ProductViewModel.IsPublisherDurationId
            };


            productRepository.Add(product);
        }


        public ProductUpdateWrapperModel GetUpdateModel(int id)
        {
            var wrapper = new ProductUpdateWrapperModel();


            var product = productRepository.GetById(id);


            if (product is null)
            {
                throw new Exception("Product not found");
            }

            wrapper.ProductViewModel = new ProductUpdateViewModel(productRepository.GetPublishDuration())
            {
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount,
                Description = product.Description,
                IsPublish = product.IsPublisher,
                IsPublisherDurationId = product.PublisherDurationId
            };


            wrapper.CategoryViewModel.CategoryId = product.CategoryId;
            wrapper.CategoryViewModel.CategorySelectList = new SelectList(categoryRepository.GetAll(), "Id", "Name");

            return wrapper;
        }


        public async Task Update(ProductUpdateWrapperModel model)
        {
        }


        public List<ProductViewModel> GetProducts()
        {
            var productList = productRepository.GetAll();
            return productList.Select(x => new ProductViewModel()
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
                    .First(y => y.Value == x.PublisherDurationId.ToString()).Text
            }).ToList();
            //List<ProductViewModel> productListViewModel = new List<ProductViewModel>();

            //foreach (var product in productList)
            //{
            //    productListViewModel.Add(new ProductViewModel()
            //    {
            //        Name = product.Name,
            //        Price = product.Price,
            //        StockCount = product.StockCount,
            //        Description = product.Description,
            //        CategoryName = product.CategoryName,
            //        PictureUrl = product.PictureUrl
            //    });
            //}

            //return productListViewModel;
        }

        public List<SelectModel> GetPublishDuration()
        {
            return productRepository.GetPublishDuration();
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}