using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public sealed class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Branch).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Items).NotNull().NotEmpty();

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId).NotEmpty();
            item.RuleFor(i => i.ProductName).NotEmpty().MaximumLength(200);
            item.RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(0m);
            item.RuleFor(i => i.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        });
    }
}
