using System.ComponentModel.DataAnnotations;

namespace WebAndAPI.Razor.Pages.Identity.ViewModels
{
    public record SignInViewModel(
        [Required(ErrorMessage = "email alanı gereklidir")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        string Email,
        [Required(ErrorMessage = "şifre alanı gereklidir")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        string Password,
        bool RememberMe)
    {
        public static SignInViewModel Empty() => new SignInViewModel(default!, default!, default!);
    }
}