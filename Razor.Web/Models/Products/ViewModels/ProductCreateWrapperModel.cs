using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Razor.Web.Models.Products.ViewModels
{
    public record ProductCreateWrapperModel
    {
        public ProductCreateViewModel ProductViewModel { get; set; } = new();

        public CategoryCreateViewModel CategoryViewModel { get; set; } = new();
    }


    public record ProductCreateViewModel
    {
        [Display(Name = "Ürün ismi :")] public string Name { get; set; } = default!;


        [DataType(DataType.Currency)]
        [Display(Name = "Ürün fiyatı :")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün açıklaması :")] public string? Description { get; set; }


        [Display(Name = "Ürün stok adet :")] public int StockCount { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Ürün resim url :")]
        public string? PictureUrl { get; set; }
    }

    public record CategoryCreateViewModel
    {
        [Display(Name = "Kategori seç :")] public SelectList CategorySelectList { get; set; } = default!;


        public int CategoryId { get; set; }


        //[Display(Name = "Kategori ismi :")] public string Name { get; set; } = default!;
    }
}