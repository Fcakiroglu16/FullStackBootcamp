using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebAndAPI.Razor.Pages.Products.ViewModels
{
    public record ProductCreateOrUpdateViewModel(string? Name, decimal Price, int Stock)
    {
        [ValidateNever] public string EncryptId { get; set; }
        public int Id { get; set; }

        public ProductCreateOrUpdateViewModel() : this(default, default, default)
        {
        }


        public void CreateEncryptId(IDataProtector dataProtector)
        {
            EncryptId = dataProtector.Protect(Id.ToString());
        }

        public void DecryptId(IDataProtector dataProtector)
        {
            if (string.IsNullOrEmpty(EncryptId)) return;
            Id = int.Parse(dataProtector.Unprotect(EncryptId));
        }

        public bool IsUpdate => Id != 0;

        public bool IsCreate => Id == 0;
    }
}