using Razor.Web.Models.Categories;
using Razor.Web.Models.Products.ViewModels;
using Razor.Web.Pages.Forms;

namespace Razor.Web.Models.Products
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


        public void Create(CreateProductModel model)
        {
            var product = new Product
            {
                Id = new Random().Next(1, 10000),
                Name = model.ProductCreateViewModel.Name,
                Price = model.ProductCreateViewModel.Price,
                StockCount = model.ProductCreateViewModel.StockCount,
                Description = model.ProductCreateViewModel.Description,
                CategoryId = model.CategoryCreateViewModel.CategoryId,
                PictureUrl = model.ProductCreateViewModel.PictureUrl
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