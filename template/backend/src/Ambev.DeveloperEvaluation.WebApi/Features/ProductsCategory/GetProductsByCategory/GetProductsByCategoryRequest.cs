namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory
{
    public class GetProductsByCategoryRequest 
    {
        public string? Category { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public string? Order { get; set; }
    }
}
