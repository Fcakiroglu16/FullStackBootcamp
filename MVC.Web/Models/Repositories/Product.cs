namespace MVC.Web.Models.Repositories
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; } = default!;
        public int StockCount { get; set; }

        public string? PictureUrl { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}