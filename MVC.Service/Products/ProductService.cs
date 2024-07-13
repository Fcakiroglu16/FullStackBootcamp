using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC.Repository;
using MVC.Repository.Products;
using MVC.Service.Products.DTOs;

namespace MVC.Service.Products
{
    public class ProductService(IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetAll()
        {
            var productList = await productRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync();

            //Manuel Way
            // return productList.Select(x => new ProductDto(x.Id, x.Name, x.Price, x.Stock)).ToList();

            var productListDto = mapper.Map<List<ProductDto>>(productList);

            return ServiceResult<List<ProductDto>>.Success(productListDto, HttpStatusCode.OK);
        }


        public async Task<ServiceResult<Product>> GetById(int id)
        {
            var hasProduct = await productRepository.GetById(id);

            if (hasProduct is null)
            {
                //return
                return ServiceResult<Product>.Fail("ürün bulunamadı", HttpStatusCode.NotFound);
            }


            return ServiceResult<Product>.Success(hasProduct, HttpStatusCode.OK);
        }
    }
}