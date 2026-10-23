using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules.ProductRules
{
	public class CreateProductValidator : AbstractValidator<CreateProductDto>
	{
		public CreateProductValidator()
		{
			RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez!");
			RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır!")
									   .MaximumLength(40).WithMessage("Ürün adı en fazla 40 karakter olmalıdır!");

			RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!")
										.GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz!")
										.LessThan(10000).WithMessage("Ürün fiyatı 10.000'den büyük olamaz!");

			RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!")
				.MinimumLength(10).WithMessage("Ürün açıklaması en az 10 karakter olmalıdır!")
				.MaximumLength(150).WithMessage("Ürün açıklaması en fazla 150 karakter olmalıdır!");

			RuleFor(x => x.ProductImageURl).NotEmpty().WithMessage("Ürün görseli boş geçilemez!")
				.MaximumLength(250).WithMessage("Ürün görsel url değeri en fazla 250 karakter olmalıdır!");
		}
	}
}
