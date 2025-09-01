using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for <see cref="GetSaleCommand"/> that defines validation rules for getting a sale.
/// </summary>
public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleCommand.
    /// </summary>
    public GetSaleCommandValidator()
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage("SaleId is required.");
    }
}
