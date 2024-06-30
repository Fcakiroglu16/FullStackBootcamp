namespace Razor.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryViewModel()
        {
        }

        public CategoryViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}