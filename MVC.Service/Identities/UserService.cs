using System.Net;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Identity;
using MVC.Repository.Identities;

namespace MVC.Service.Identities
{
    public class UserService(UserManager<AppUser> userManager) : IUserService
    {
        public async Task<ServiceResult> SignUp(SignUpDto request)
        {
            var hasUser = await userManager.FindByEmailAsync(request.Email);

            if (hasUser is not null)
            {
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


            return ServiceResult.Success(HttpStatusCode.Created);
        }
    }
}