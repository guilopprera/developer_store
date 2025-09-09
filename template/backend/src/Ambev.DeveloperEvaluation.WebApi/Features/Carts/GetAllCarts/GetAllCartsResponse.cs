using Ambev.DeveloperEvaluation.WebApi.Common.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;

public class GetAllCartsResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<CartItemResponse> Items { get; init; } = [];
}
