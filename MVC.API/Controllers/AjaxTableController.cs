using System.Net;
using Microsoft.AspNetCore.Mvc;
using MVC.Service;
using MVC.Service.Products.DTOs;

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxTableController : ControllerBase
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
    }
}