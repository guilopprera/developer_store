using Ambev.DeveloperEvaluation.Application.Common.Carts;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartResult
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<CartItemDto> Items { get; init; } = [];
}