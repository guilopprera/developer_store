using Ambev.DeveloperEvaluation.Application.Common.Carts;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<CartItemDto> Items { get; set; } = new();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}