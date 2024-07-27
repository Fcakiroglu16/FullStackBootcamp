namespace MVC.Service.Identities.Options
{
    public record ClientCredentialsOption
    {
        public List<ClientCredential> Clients { get; set; } = default!;
        public int ExpireAsHour { get; set; } = default!;
    }


    public record ClientCredential
    {
        public string Id { get; init; } = default!;
        public string Secret { get; init; } = default!;
    }
}