using Microsoft.AspNetCore.Mvc;
using MVC.Service.Products;
using MVC.Service.Products.DTOs;

namespace MVC.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : CustomControllerBase
    {
        #region Methot Types

        // Get => data almak
        // Post => data eklemek
        // Put   => data güncellemek
        // Delete => data silmek
        // Patch => Kısmı güncelleme

        // Request Header ( key-value) Meta Info => Version=v1, Token=123,TenantId=1
        // Request  Body ( Json)
        // Request Url Route Data ( id, page, pageIndex)
        // Request URl Query String(?id=10&name=ali)

        #endregion

        // http://localhost/api/products
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateResult(await productService.GetAll());

        // http://localhost/api/products/1/2
        [HttpGet("{page:int}/{pageIndex:int}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageIndex) =>
            CreateResult(await productService.GetAllByPaging(page, pageIndex));


        // http://localhost/api/products?id=10
        //http://localhost/api/products/10

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CreateResult(await productService.GetById(id));


        [HttpPost("ByCategory")]
        public async Task<IActionResult> CreateByCategory(ProductCreateByCategoryDto request)
        {
            return Created();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto request) =>
            CreateResult(await productService.Create(request));


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto request) =>
            CreateResult(await productService.Update(request));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => CreateResult(await productService.Delete(id));
    }
}