using MVC.Service.Products.DTOs;

namespace MVC.Service.Products;

public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetAll();

    Task<ServiceResult<ProductDto>> GetById(int id);

    Task<ServiceResult<ProductDto>> Create(ProductCreateDto request);
    Task<ServiceResult> Update(ProductUpdateDto request);

    Task<ServiceResult> Delete(int id);

    Task<ServiceResult<List<ProductDto>>> GetAllByPaging(int page, int pageSize);
}