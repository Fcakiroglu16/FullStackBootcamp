using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace MVC.API.Controllers
{
    public record KeyValueDto(int Id, string Value);


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCountry()
        {
            var countryList = new List<KeyValueDto>
            {
                new(1, "Türkiye"),
                new(2, "Almanya")
            };


            return Ok(countryList);
        }

        [HttpGet("{countryId}")]
        public IActionResult GetProvince(int countryId)
        {
            var provinceList = new List<KeyValueDto>();


            if (countryId == 1)
            {
                provinceList.Add(new(1, "İstanbul"));
                provinceList.Add(new(1, "Ankara"));
                provinceList.Add(new(1, "İzmir"));
            }


            return Ok(provinceList);
        }
    }
}