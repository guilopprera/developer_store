using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Items).NotNull().NotEmpty();

        RuleForEach(x => x.Items).ChildRules(i =>
        {
            i.RuleFor(p => p.ProductId).NotEmpty();
            i.RuleFor(p => p.Quantity).GreaterThan(0);
        });
    }
}
