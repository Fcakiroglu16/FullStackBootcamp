using MVC.Web.Models;

namespace Razor.Web.Models.Categories
{
    public class CategoryService
    {
        private CategoryRepository categoryRepository;


        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public List<CategoryViewModel> GetAll()
        {
            return categoryRepository.GetAll().Select(category => new CategoryViewModel(category.Id, category.Name))
                .ToList();
        }
    }
}