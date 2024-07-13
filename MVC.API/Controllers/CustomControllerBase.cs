using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Service;

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        public ObjectResult CreateResult<T>(ServiceResult<T> result)
        {
            return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
        }
    }
}