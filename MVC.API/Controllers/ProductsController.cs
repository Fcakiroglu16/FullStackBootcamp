using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
        public async Task<IActionResult> GetAll()
        {
            //return new OkResult();
            //return new OkObjectResult();
            return Ok();
        }

        // http://localhost/api/products/1/2
        [HttpGet("{page:int}/{pageIndex:int}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageIndex)
        {
            return Ok();
        }


        // http://localhost/api/products?id=10
        //http://localhost/api/products/10

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }


        [HttpPost("ByCategory")]
        public async Task<IActionResult> CreateByCategory(ProductCreateByCategoryDto request)
        {
            return Created();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto request)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return NoContent();
        }
    }
}