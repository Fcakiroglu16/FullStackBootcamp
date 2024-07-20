namespace WebAndAPI.Razor.Pages.Identity.Dtos
{
    public record SignInResponseDto(string UserId, string Email, string UserName, List<string> Roles);
}