using Microsoft.AspNetCore.DataProtection;

namespace WebAndAPI.Razor.Services.Products.ViewModels
{
    public record ProductViewModel(int Id, string Name, decimal Price, int Stock)
    {
        public int Id { get; set; } = Id;

        public string Name { get; set; } = Name;
        public decimal Price { get; set; } = Price;
        public int Stock { get; set; } = Stock;

        public string? EncryptId { get; set; }


        public void CreateEncryptId(IDataProtector dataProtector)
        {
            EncryptId = dataProtector.Protect(Id.ToString());
        }

        public void DecryptId(IDataProtector dataProtector)
        {
            Id = int.Parse(dataProtector.Unprotect(EncryptId));
        }
    }
}