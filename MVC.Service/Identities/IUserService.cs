namespace MVC.Service.Identities;

public interface IUserService
{
    Task<ServiceResult> SignUp(SignUpDto request);

    Task<ServiceResult<TokenResponseDto>> SignIn(SignInDto request);

    Task<ServiceResult> AddRoleToUser(Guid userId, string roleName);
}