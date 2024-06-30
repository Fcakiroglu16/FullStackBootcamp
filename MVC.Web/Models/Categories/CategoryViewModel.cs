namespace MVC.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public CategoryViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}