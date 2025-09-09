using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetCartValidator : AbstractValidator<GetCartCommand>
{
    public GetCartValidator()
    {
        RuleFor(c => c)
            .NotEmpty().WithMessage("Cart Id is required.");
    }
}
