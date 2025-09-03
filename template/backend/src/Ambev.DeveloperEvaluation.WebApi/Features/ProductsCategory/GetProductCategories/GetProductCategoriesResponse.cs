namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductCategories
{
    public class GetProductCategoriesResponse
    {
        public IReadOnlyList<string> Categories { get; set; } = Array.Empty<string>();
    }
}
