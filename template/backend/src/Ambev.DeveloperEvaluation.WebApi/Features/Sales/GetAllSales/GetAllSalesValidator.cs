using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesValidator : AbstractValidator<GetAllSalesRequest>
{
    public GetAllSalesValidator()
    {
        RuleFor(s => s.Page).GreaterThanOrEqualTo(1);
        RuleFor(s => s.Size).InclusiveBetween(1, 100);
    }
}
