using MVC.Web.Models.Categories;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Services
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