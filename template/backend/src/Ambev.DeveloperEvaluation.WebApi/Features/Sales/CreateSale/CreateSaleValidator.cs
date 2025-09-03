using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class CreateSaleValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("CustomerName is required.")
            .MaximumLength(200).WithMessage("CustomerName must not exceed 200 characters.");

        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch is required.")
            .MaximumLength(100).WithMessage("Branch must not exceed 100 characters.");

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Items collection is required.")
            .NotEmpty().WithMessage("At least one item is required.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            item.RuleFor(i => i.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("UnitPrice must be greater or equal to zero.");
        });
    }
}
