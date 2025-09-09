using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetCartCommand : IRequest<GetCartResult>
{
    public Guid Id { get; set; }


    public GetCartCommand(Guid id)
    {
        Id = id;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new GetCartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}