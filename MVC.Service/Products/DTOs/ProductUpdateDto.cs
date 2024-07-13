namespace MVC.Service.Products.DTOs
{
    public record ProductUpdateDto(int Id, string Name, decimal Price, int Stock);
}