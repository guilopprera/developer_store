using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetAllCartsCommand : IRequest<GetAllCartsPageResult>
{
    public GetAllCartsCommand(int page, int size, string? order)
    {
        Page = page;
        Size = size;
        Order = order;
    }

    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new GetAllCartsValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}