namespace MVC.Web.Models.Products.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string? Description { get; set; }

        public string? PictureUrl { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}