namespace WebAndAPI.Razor.Pages.Identity
{
    public record SignInViewModel(string Email, string Password)
    {
        public static SignInViewModel Empty() => new SignInViewModel(default!, default!);
    }
}