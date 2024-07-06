using System.Security.Policy;

namespace MVC.Web.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockCount { get; set; }

        public string? PictureUrl { get; set; }

        public bool IsPublisher { get; set; }

        public int PublisherDurationId { get; set; }
        public int CategoryId { get; set; }

        public DateTime PublishExpire { get; set; }
    }
}