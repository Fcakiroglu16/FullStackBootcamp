using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products.ViewModels
{
    public record ProductCreateWrapperModel : BaseWrapperModel
    {
        public ProductCreateViewModel ProductViewModel { get; set; } = new();

        public CategoryCreateViewModel CategoryViewModel { get; set; } = new();
    }


    public record ProductCreateViewModel
    {
        public ProductCreateViewModel()
        {
        }

        public ProductCreateViewModel(List<SelectModel> isPublisherDurationList)
        {
            IsPublisherDurationList = isPublisherDurationList;
        }


        [Display(Name = "Ürün resmi:")] public IFormFile? ImageFile { get; set; } = default!;


        [Display(Name = "Ürün yayınlanma süresi :")]
        public List<SelectModel>? IsPublisherDurationList { get; set; } = default!;

        [Required(ErrorMessage = "ürün yayınlanma süresi seçiniz")]
        public int? IsPublisherDurationId { get; set; }


        [Remote(action: "HasProduct", controller: "Products", AdditionalFields = "Name")]
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

        [ValidateNever]
        [DataType(DataType.Url)]
        [Display(Name = "Ürün resim url :")]
        public string? PictureUrl { get; set; }


        [Display(Name = "Ürün yayınlansın mı? :")]
        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Tarih belirtiniz.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ürün yayından kaldırılma tarihi :")]
        public DateTime? PublishExpire { get; set; }
    }

    public record CategoryCreateViewModel
    {
        [Display(Name = "Kategori seç :")] public SelectList? CategorySelectList { get; set; } = default!;

        [Required(ErrorMessage = "kategori ismi seçiniz")]
        public int? CategoryId { get; set; }


        //[Display(Name = "Kategori ismi :")] public string Name { get; set; } = default!;
    }
}