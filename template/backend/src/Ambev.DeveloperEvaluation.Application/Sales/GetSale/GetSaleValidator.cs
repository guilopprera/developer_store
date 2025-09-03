using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleCommandValidator()
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage("SaleId is required.");
    }
}
