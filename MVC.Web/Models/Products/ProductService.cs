using MVC.Web.Models.Categories;
using MVC.Web.Models.Products;
using MVC.Web.Models.Products.ViewModels;

namespace MVC.Web.Models.Services
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


        public void Create(ProductCreateWrapperModel model)
        {
            var product = new Product
            {
                Id = new Random().Next(1, 10000),
                Name = model.ProductViewModel.Name,
                Price = model.ProductViewModel.Price,
                StockCount = model.ProductViewModel.StockCount,
                Description = model.ProductViewModel.Description,
                CategoryId = model.CategoryViewModel.CategoryId,
                PictureUrl = model.ProductViewModel.PictureUrl
            };

            productRepository.Add(product);
        }

        public List<ProductViewModel> GetProducts()
        {
            var productList = productRepository.GetAll();

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


            return productList.Select(x => new ProductViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                StockCount = x.StockCount,
                Description = x.Description,
                CategoryName = categoryRepository.GetById(x.CategoryId)!.Name,
                PictureUrl = x.PictureUrl
            }).ToList();
        }
    }
}