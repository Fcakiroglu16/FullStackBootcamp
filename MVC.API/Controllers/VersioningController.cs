using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.API.Controllers
{
    [ApiVersion(2)]
    [ApiVersion(1, Deprecated = true)]
    [Route("api/[controller]")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class VersioningController : ControllerBase
    {
        [HttpGet("GetList")]
        [MapToApiVersion(1)]
        public IActionResult GetList()
        {
            return Ok("1. version");
        }


        [HttpGet("GetList")]
        [MapToApiVersion(2)]
        public IActionResult GetListV2()
        {
            return Ok("2. version");
        }
    }
}