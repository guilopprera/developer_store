namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;

public class GetAllCartsPageResponse
{
    public List<GetAllCartsResponse> Carts { get; set; } = [];
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}