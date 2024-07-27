﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Service.Identities;
using MVC.Service.OpenTelemetry;

namespace MVC.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(
        IUserService userService,
        ITokenService tokenService,
        ILogger<IdentityController> logger) : CustomControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto request)
        {
            logger.LogInformation("SignUp endpoint çalışmaya başladı.");
            return CreateResult(await userService.SignUp(request));
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto request) => CreateResult(await userService.SignIn(request));

        [AllowAnonymous]
        [HttpPost("SignInWithClientCredential")]
        public IActionResult SignInWithClientCredential(ClientCredentialRequestDto request) =>
            CreateResult(tokenService.GetTokenWithClientCredential(request));


        [HttpPost("AddRoleToUser/{userId:guid}/{roleName}")]
        public async Task<IActionResult> AddRoleToUser(Guid userId, string roleName) =>
            CreateResult(await userService.AddRoleToUser(userId, roleName));
    }
}