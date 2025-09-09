namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;

public class GetAllCartsRequest
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }
}