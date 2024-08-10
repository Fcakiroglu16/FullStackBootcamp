using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.API.Helpers;
using MVC.Repository;
using MVC.Repository.Categories;
using MVC.Service;
using MVC.Service.Categories;
using MVC.Service.Products.DTOs;

namespace MVC.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxTableController(
        IGenericRepository<Category> categoryRepository,
        [FromKeyedServices("ProductHelper")] IHelper helper) : ControllerBase
    {
        private static readonly List<(string categoryName, List<ProductDto> products)> Products = new();

        //private static List<Tuple<string,List<ProductDto>>> _products = new();
        static AjaxTableController()
        {
            Products.Add(("kalemler", [new ProductDto(1, "Kalem 1", 100, 10)]));
            Products.Add(("kalemler", [new ProductDto(2, "Kalem 2", 200, 20)]));
            Products.Add(("kalemler", [new ProductDto(3, "Kalem 3", 300, 30)]));
            Products.Add(("kitaplar", [new ProductDto(4, "kitap 1", 400, 40)]));
            Products.Add(("kitaplar", [new ProductDto(5, "kitap 2", 500, 50)]));
            Products.Add(("kitaplar", [new ProductDto(6, "kitap 3", 600, 60)]));
            Products.Add(("silgiler", [new ProductDto(7, "silgi 1", 600, 60)]));
            Products.Add(("silgiler", [new ProductDto(8, "silgi 2", 700, 70)]));
            Products.Add(("silgiler", [new ProductDto(9, "silgi 3", 800, 80)]));
        }

        [HttpGet("{categoryName}")]
        public IActionResult GetProducts(string categoryName)
        {
            categoryName = categoryName.ToLowerInvariant();
            var products = Products.Where(x => x.categoryName.ToLowerInvariant() == categoryName)
                .SelectMany(x => x.products).ToList();


            return Ok(ServiceResult<List<ProductDto>>.Success(products, HttpStatusCode.OK));
        }

        [HttpGet("GetCategoryNameList")]
        public async Task<IActionResult> GetCategoryNameList()
        {
            var categoryList = await categoryRepository.GetAll().ToListAsync();


            var categoryListAsDto = categoryList.Select(x => new CategoryDto(x.Id, x.Name)).ToList();

            return Ok(ServiceResult<List<CategoryDto>>.Success(categoryListAsDto, HttpStatusCode.OK));
        }
    }
}