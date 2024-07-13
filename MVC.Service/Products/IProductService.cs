using MVC.Service.Products.DTOs;

namespace MVC.Service.Products;

public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetAll();
}