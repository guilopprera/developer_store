using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

public class GetCartValidator : AbstractValidator<GetCartRequest>
{
    public GetCartValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Cart ID is required");
    }
}