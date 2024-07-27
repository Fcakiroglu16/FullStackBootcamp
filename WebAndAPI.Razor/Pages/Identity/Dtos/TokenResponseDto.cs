namespace WebAndAPI.Razor.Pages.Identity.Dtos
{
    public record TokenResponseDto(string AccessToken, string RefreshToken, long RefreshTokenExpire);
}