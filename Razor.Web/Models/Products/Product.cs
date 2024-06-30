namespace Razor.Web.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockCount { get; set; }

        public string? PictureUrl { get; set; }
        public int CategoryId { get; set; }
    }
}