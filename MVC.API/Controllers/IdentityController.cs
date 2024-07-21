using Microsoft.AspNetCore.Mvc;
using MVC.Service.Identities;
using MVC.Service.OpenTelemetry;

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IUserService userService, ILogger<IdentityController> logger) : CustomControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto request)
        {
            logger.LogInformation("SignUp endpoint çalışmaya başladı.");
            return CreateResult(await userService.SignUp(request));
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto request) => CreateResult(await userService.SignIn(request));


        [HttpPost("AddRoleToUser/{userId:guid}/{roleName}")]
        public async Task<IActionResult> AddRoleToUser(Guid userId, string roleName) =>
            CreateResult(await userService.AddRoleToUser(userId, roleName));
    }
}