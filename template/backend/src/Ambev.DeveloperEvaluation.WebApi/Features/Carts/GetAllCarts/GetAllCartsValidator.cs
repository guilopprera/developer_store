using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

public class GetAllCartsValidator : AbstractValidator<GetAllCartsRequest>
{
    public GetAllCartsValidator()
    {
        RuleFor(p => p.Page).GreaterThanOrEqualTo(1);
        RuleFor(p => p.Size).InclusiveBetween(1, 100);
    }
}