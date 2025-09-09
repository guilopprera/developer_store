using Ambev.DeveloperEvaluation.Application.Common.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;

public class GetCartResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<CartItemDto> Items { get; init; } = [];
}
