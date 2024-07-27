namespace MVC.Repository.Identities
{
    public class RefreshToken
    {
        public string Token { get; set; } = default!;


        public Guid UserId { get; set; }
        public DateTime Expire { get; set; }
    }
}