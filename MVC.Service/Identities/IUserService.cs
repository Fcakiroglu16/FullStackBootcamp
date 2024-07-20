namespace MVC.Service.Identities;

public interface IUserService
{
    Task<ServiceResult> SignUp(SignUpDto request);
}