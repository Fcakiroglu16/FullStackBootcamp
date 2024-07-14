using System.Net;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC.Repository;
using MVC.Repository.Data;
using MVC.Repository.Products;
using MVC.Service.Products.DTOs;

namespace MVC.Service.Products
{
    public class ProductService(
        IGenericRepository<Product> productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        AppDbContext context)
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


        public async Task<ServiceResult<ProductDto>> GetById(int id)
        {
            var hasProduct = await productRepository.GetById(id);

            if (hasProduct is null)
            {
                //return
                return ServiceResult<ProductDto>.Fail("ürün bulunamadı", HttpStatusCode.NotFound);
            }


            return ServiceResult<ProductDto>.Success(mapper.Map<ProductDto>(hasProduct), HttpStatusCode.OK);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllByPaging(int page, int pageSize)
        {
            var productList = await productRepository.GetAllByPaging(page, pageSize).OrderByDescending(x => x.Id)
                .ToListAsync();

            //Manuel Way
            // return productList.Select(x => new ProductDto(x.Id, x.Name, x.Price, x.Stock)).ToList();

            var productListDto = mapper.Map<List<ProductDto>>(productList);

            return ServiceResult<List<ProductDto>>.Success(productListDto, HttpStatusCode.OK);
        }


        public async Task<ServiceResult<ProductDto>> Create(ProductCreateDto request)
        {
            var product = mapper.Map<Product>(request);

            await productRepository.Create(product);
            await unitOfWork.CommitAsync();


            return ServiceResult<ProductDto>.Success(mapper.Map<ProductDto>(product), HttpStatusCode.Created);
        }


        public async Task<ServiceResult> Update(ProductUpdateDto request)
        {
            //change tracker
            var hasProduct = productRepository.Any(x => x.Id == request.Id);


            if (!hasProduct)
            {
                return ServiceResult.Fail("güncellemeye çalıştığınız ürün bulunamadı.", HttpStatusCode.NotFound);
            }


            var product = mapper.Map<Product>(request);

            var state = context.Entry(product).State;


            productRepository.Update(product);
            await unitOfWork.CommitAsync();


            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


        public async Task<ServiceResult> Delete(int id)
        {
            var hasProduct = await productRepository.GetById(id);

            if (hasProduct is null)
            {
                return ServiceResult.Fail("silmeye çalıştığınız ürün bulunamadı.", HttpStatusCode.NotFound);
            }

            productRepository.Delete(hasProduct);
            await unitOfWork.CommitAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}