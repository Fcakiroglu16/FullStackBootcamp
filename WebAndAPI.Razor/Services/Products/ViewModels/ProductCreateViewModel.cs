using System.ComponentModel.DataAnnotations;

namespace WebAndAPI.Razor.Services.Products.ViewModels
{
    public record ProductCreateOrUpdateViewModel(int Id, string? Name, decimal Price, int Stock)
    {
        public ProductCreateOrUpdateViewModel() : this(default, default, default, default)
        {
        }


        public bool IsUpdate => Id != 0;

        public bool IsCreate => Id == 0;
    }
}