using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetAllCartsValidator : AbstractValidator<GetAllCartsCommand>
{
    public GetAllCartsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("Page must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage("Size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Size must not exceed 100.");
    }
}
