using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Service.Identities;

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IUserService userService) : CustomControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto request) => CreateResult(await userService.SignUp(request));
    }
}