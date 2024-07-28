using System.Diagnostics;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MVC.Repository.Identities;

namespace MVC.Service.Identities
{
    public class UserService(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        ILogger<UserService> logger,
        ITokenService tokenService) : IUserService
    {
        public async Task<ServiceResult> SignUp(SignUpDto request)
        {
            var hasUser = await userManager.FindByEmailAsync(request.Email);

            if (hasUser is not null)
            {
                logger.LogInformation("Email adresi olmadığı için kullanıcı bulunamadı");
                return ServiceResult.Fail("Email adresi başka bir kullanıcı tarafından kullanılıyor",
                    HttpStatusCode.BadRequest);
            }

            hasUser = await userManager.FindByNameAsync(request.UserName);


            if (hasUser is not null)
            {
                return ServiceResult.Fail("Kullanıcı adı başka bir kullanıcı tarafından kullanılıyor",
                    HttpStatusCode.BadRequest);
            }


            var newUser = AppUser.Create(request.Email, request.UserName, request.City);
            var result = await userManager.CreateAsync(newUser, request.Password);


            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ServiceResult.Fail(errors, HttpStatusCode.BadRequest);
            }


            var httpClient = new HttpClient();
            var httpResult = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            logger.LogInformation("Kullanıcı oluştu");
            return ServiceResult.Success(HttpStatusCode.Created);
        }

        public async Task<ServiceResult<TokenResponseDto>> SignIn(SignInDto request)
        {
            var hasUser = await userManager.FindByEmailAsync(request.Email);


            if (hasUser is null)
            {
                return ServiceResult<TokenResponseDto>.Fail("Email veya şifre hatalı", HttpStatusCode.NotFound);
            }

            var checkPassword = await userManager.CheckPasswordAsync(hasUser, request.Password);


            if (!checkPassword)
            {
                return ServiceResult<TokenResponseDto>.Fail("Email veya şifre hatalı", HttpStatusCode.NotFound);
            }


            var roles = await userManager.GetRolesAsync(hasUser);


            var tokenResponse = await tokenService.GetTokenWithResourceOwnerAsync(hasUser, roles.ToList());


            if (!tokenResponse.IsSuccess)
            {
                return ServiceResult<TokenResponseDto>.Fail(tokenResponse.Errors!, HttpStatusCode.InternalServerError);
            }


            return ServiceResult<TokenResponseDto>.Success(tokenResponse.Data!, HttpStatusCode.OK);
        }

        public async Task<ServiceResult> AddRoleToUser(Guid userId, string roleName)
        {
            var hasUser = await userManager.FindByIdAsync(userId.ToString());

            if (hasUser is null)
            {
                return ServiceResult.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            roleName = roleName.ToLower();
            var hasRole = await roleManager.FindByNameAsync(roleName);
            if (hasRole is null)
            {
                await roleManager.CreateAsync(new AppRole() { Name = roleName });
            }

            var result = await userManager.AddToRoleAsync(hasUser, roleName);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ServiceResult.Fail(errors, HttpStatusCode.BadRequest);
            }

            return ServiceResult.Success(HttpStatusCode.OK);
        }
    }
}