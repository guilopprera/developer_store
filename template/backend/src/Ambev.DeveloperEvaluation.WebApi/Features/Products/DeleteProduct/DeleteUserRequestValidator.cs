using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
