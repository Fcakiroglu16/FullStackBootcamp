namespace MVC.Web.Models.Repositories
{
    public class ProductService
    {
        private ProductRepository productRepository;


        public ProductService()
        {
            productRepository = new ProductRepository();
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
                CategoryName = model.CategoryViewModel.Name,
                PictureUrl = model.ProductViewModel.PictureUrl
            };

            productRepository.Add(product);
        }

        public List<ProductViewModel> GetProducts()
        {
            return productRepository.GetAll().Select(x => new ProductViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                StockCount = x.StockCount,
                Description = x.Description,
                CategoryName = x.CategoryName,
                PictureUrl = x.PictureUrl
            }).ToList();
        }
    }
}