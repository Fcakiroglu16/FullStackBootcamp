namespace MVC.Service.Identities.Options
{
    public class TokenOption
    {
        public int RefreshTokenExpireAsHour { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string SignatureKey { get; set; } = default!;
        public string ExpireAsHour { get; set; } = default!;
    }
}