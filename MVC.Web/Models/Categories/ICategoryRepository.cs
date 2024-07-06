namespace MVC.Web.Models.Categories;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category? GetById(int id);
}