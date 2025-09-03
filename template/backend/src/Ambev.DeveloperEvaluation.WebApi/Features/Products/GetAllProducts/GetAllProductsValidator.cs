using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsValidator : AbstractValidator<GetAllProductsRequest>
{
    public GetAllProductsValidator()
    {
        RuleFor(p => p.Page).GreaterThanOrEqualTo(1);
        RuleFor(p => p.Size).InclusiveBetween(1, 100);
    }
}
