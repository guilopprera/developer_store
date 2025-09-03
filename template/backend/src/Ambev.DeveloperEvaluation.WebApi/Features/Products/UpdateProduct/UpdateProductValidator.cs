using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0m);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Image).MaximumLength(500);
        RuleFor(x => x.Description).MaximumLength(2000);
        RuleFor(x => x.RatingRate).InclusiveBetween(0, 5);
        RuleFor(x => x.RatingCount).GreaterThanOrEqualTo(0);
    }
}
