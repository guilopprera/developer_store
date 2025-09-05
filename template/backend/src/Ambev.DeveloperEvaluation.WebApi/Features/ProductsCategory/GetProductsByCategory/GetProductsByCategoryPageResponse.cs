namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory
{
    public class GetProductsByCategoryPageResponse
    {
        public IReadOnlyList<GetProductsByCategoryResponse> Products { get; set; } = [];
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
