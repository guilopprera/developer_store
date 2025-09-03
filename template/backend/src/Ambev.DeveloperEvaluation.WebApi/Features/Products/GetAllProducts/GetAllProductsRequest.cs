namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsRequest
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }
}
