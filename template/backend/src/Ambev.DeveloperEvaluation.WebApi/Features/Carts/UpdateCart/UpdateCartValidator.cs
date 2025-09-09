using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required");
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        });
    }
}