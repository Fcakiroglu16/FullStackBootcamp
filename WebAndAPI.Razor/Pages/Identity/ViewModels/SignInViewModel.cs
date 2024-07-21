using System.ComponentModel.DataAnnotations;

namespace WebAndAPI.Razor.Pages.Identity.ViewModels
{
    public record SignInViewModel
    {
        [Required(ErrorMessage = "email alanı gereklidir")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required(ErrorMessage = "şifre alanı gereklidir")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        public bool RememberMe { get; init; }

        public SignInViewModel(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }

        public SignInViewModel()
        {
        }
    }


    //public record SignInViewModel(
    //    [Required(ErrorMessage = "email alanı gereklidir")]
    //    [Display(Name = "Email:")]
    //    [DataType(DataType.EmailAddress)]
    //    string Email,
    //    [Required(ErrorMessage = "şifre alanı gereklidir")]
    //    [Display(Name = "Şifre:")]
    //    [DataType(DataType.Password)]
    //    string Password,
    //    bool RememberMe)
    //{
    //    public static SignInViewModel Empty() => new SignInViewModel(default!, default!, default!);
    //}
}