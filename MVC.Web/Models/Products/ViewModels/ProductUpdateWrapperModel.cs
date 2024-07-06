using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC.Web.Models.Products.ViewModels
{
    public record ProductUpdateWrapperModel : BaseWrapperModel
    {
        public ProductUpdateViewModel ProductViewModel { get; set; } = new();
        public CategoryUpdateViewModel CategoryViewModel { get; set; } = new();
    }


    public record ProductUpdateViewModel
    {
        public ProductUpdateViewModel()
        {
        }

        public ProductUpdateViewModel(List<SelectModel> isPublisherDurationList)
        {
            IsPublisherDurationList = isPublisherDurationList;
        }


        public int Id { get; set; }


        [Display(Name = "Ürün resmi:")] public IFormFile? ImageFile { get; set; } = default!;


        [Display(Name = "Ürün yayınlanma süresi :")]
        public List<SelectModel>? IsPublisherDurationList { get; private set; } = default!;


        [Required(ErrorMessage = "ürün yayınlanma süresi seçiniz")]
        public int? IsPublisherDurationId { get; set; }

        [StringLength(30, ErrorMessage = "ürün ismi en fazla 30 karakter olabilir.")]
        [Required(ErrorMessage = "ürün ismi boş geçilemez")]
        [Display(Name = "Ürün ismi :")]
        public string Name { get; set; } = default!;


        [Required(ErrorMessage = "ürün fiyatı boş geçilemez")]
        [DataType(DataType.Currency)]
        [Display(Name = "Ürün fiyatı :")]
        public decimal? Price { get; set; }


        [ValidateNever]
        [Display(Name = "Ürün açıklaması :")]
        public string? Description { get; set; }

        [Range(1, 5000, ErrorMessage = "stok miktarı 1 ile 5000 arasında olmalıdır")]
        [Display(Name = "Ürün stok adet :")]
        public int StockCount { get; set; }


        [DataType(DataType.Url)]
        [Display(Name = "Ürün resim url :")]
        public string? PictureUrl { get; set; }


        [Display(Name = "Ürün yayınlansın mı? :")]
        public bool IsPublish { get; set; }


        public bool IsPublisherChecked(string isPublisherDurationId)
        {
            return IsPublisherDurationId.ToString() == isPublisherDurationId;
        }
    }


    public record CategoryUpdateViewModel
    {
        [Display(Name = "Kategori seç :")] public SelectList? CategorySelectList { get; set; } = default!;


        public int CategoryId { get; set; }


        //[Display(Name = "Kategori ismi :")] public string Name { get; set; } = default!;
    }
}