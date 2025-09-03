using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("SaleId is required.");

        RuleFor(s => s.CustomerName)
            .NotEmpty().MaximumLength(200);

        RuleFor(s => s.Branch)
            .NotEmpty().MaximumLength(100);

        RuleFor(s => s.Items)
            .NotNull().NotEmpty();

        RuleForEach(s => s.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId).NotEmpty();
            item.RuleFor(i => i.ProductName).NotEmpty().MaximumLength(200);
            item.RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(0m);
            item.RuleFor(i => i.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        });
    }
}
