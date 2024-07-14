using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MVC.Service.Products.DTOs;

namespace MVC.Service.Products.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz")
                .NotNull().WithMessage("İsim alanı boş olamaz");

            RuleFor(x => x.Price).InclusiveBetween(1, decimal.MaxValue)
                .WithMessage("Fiyat değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("Stock değeri 0'dan büyük olmalıdır.");
        }
    }
}