namespace Razor.Web.Models.Categories
{
    public class CategoryRepository
    {
        private static List<Category> categoryList =
        [
            new Category() { Id = 1, Name = "Kalemler" },
            new Category() { Id = 2, Name = "Kitaplar" },
            new Category() { Id = 3, Name = "Defterler" }
        ];

        public List<Category> GetAll()
        {
            return categoryList;
        }
    }
}