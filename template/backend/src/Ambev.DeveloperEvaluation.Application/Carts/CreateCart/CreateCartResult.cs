
using Ambev.DeveloperEvaluation.Application.Common.Carts;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartResult
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<CartItemDto> Items { get; init; } = [];
}
