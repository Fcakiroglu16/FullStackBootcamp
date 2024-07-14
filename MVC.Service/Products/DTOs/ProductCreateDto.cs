using System.ComponentModel.DataAnnotations;

namespace MVC.Service.Products.DTOs
{
    public record ProductCreateDto(string Name, decimal Price, int Stock);
}