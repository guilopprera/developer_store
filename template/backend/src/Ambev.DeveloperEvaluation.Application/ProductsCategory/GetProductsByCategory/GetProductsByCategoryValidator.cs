using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;

public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryCommand>
{
    public GetProductsByCategoryValidator()
    {
        RuleFor(p=> p.Category).NotNull().WithMessage("Category name is required");
    }
}
