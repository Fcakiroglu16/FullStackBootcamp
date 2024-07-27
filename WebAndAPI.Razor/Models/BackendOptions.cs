namespace WebAndAPI.Razor.Models
{
    public class BackendOptions
    {
        public const string Backend = "BackendOptions";
        public string BaseUrl { get; set; } = default!;

        public string ClientId { get; set; } = default!;

        public string ClientSecret { get; set; } = default!;
    }
}