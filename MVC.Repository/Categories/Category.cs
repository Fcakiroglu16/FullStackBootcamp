using MVC.Repository.Products;

namespace MVC.Repository.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        //navigation property
        public List<Product>? Products { get; set; }
    }
}