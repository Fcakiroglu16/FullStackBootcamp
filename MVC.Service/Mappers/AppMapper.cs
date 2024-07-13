using AutoMapper;
using MVC.Repository.Products;
using MVC.Service.Products.DTOs;

namespace MVC.Service.Mappers
{
    internal class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}