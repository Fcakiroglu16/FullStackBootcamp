using System.ComponentModel.DataAnnotations;

namespace WebAndAPI.Razor.Pages.Identity
{
    public record SignUpViewModel(
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez")]
        string UserName,
        [Required(ErrorMessage = "email boş geçilemez")]
        [DataType((DataType.EmailAddress))]
        string Email,
        [MinLength(4, ErrorMessage = "şifre minimum 4 karakter olmalıdır")]
        [Required(ErrorMessage = "şifre boş geçilemez")]
        [DataType(DataType.Password)]
        string Password,
        string? City)
    {
        public SignUpViewModel() : this(default, default, default, default)
        {
        }

        public static SignUpViewModel Empty() => new SignUpViewModel();
    }
}