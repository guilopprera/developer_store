using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory
{
    public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryRequest>
    {
        public GetProductsByCategoryValidator()
        {
            RuleFor(p => p.Category).NotNull().WithMessage("Category name is required");
        }
    }
}
