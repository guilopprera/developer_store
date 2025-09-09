using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("User Id is required.");

        RuleFor(c => c.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(c => c.Items)
            .NotNull().WithMessage("Items can't be empty.")
            .Must(items => items.Any()).WithMessage("The cart should countains at least one item.");

        RuleForEach(c => c.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity should be greater than zero.")
                .LessThanOrEqualTo(100).WithMessage("Max quantity per item is 100.");
        });
    }
}
