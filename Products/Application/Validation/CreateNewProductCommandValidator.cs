using Avanade.eShop.Application.Commands;
using FluentValidation;

namespace Avanade.eShop.Application.Validation
{
	public class CreateNewProductCommandValidator : AbstractValidator<CreateNewProductCommand>
    {
		public CreateNewProductCommandValidator()
		{
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.ProductName).NotEmpty().MaximumLength(200);
			RuleFor(x => x.ProductCode).NotEmpty().Length(10);
			RuleFor(x => x.Description).NotEmpty();
			RuleFor(x => x.ReleaseDate).NotEmpty();
			RuleFor(x => x.StarRating).InclusiveBetween(0.0f, 5.0f);
		}
	}
}
