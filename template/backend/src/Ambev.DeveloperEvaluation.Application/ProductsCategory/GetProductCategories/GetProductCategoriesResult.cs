namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductCategories;

public class GetProductCategoriesResult
{
    public GetProductCategoriesResult(IReadOnlyList<string> categories)
    {
        Categories = categories;
    }
    public IReadOnlyList<string> Categories { get; set; } = Array.Empty<string>();
}