using System.ComponentModel.DataAnnotations.Schema;
using MVC.Repository.Categories;
using MVC.Repository.Data;

namespace MVC.Repository.Products
{
    public class Product : BaseUserEntity<int>, IAuditByDate, IAuditByUser
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public Guid? CreatedByUser { get; set; }
        public Guid? UpdatedByUser { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}