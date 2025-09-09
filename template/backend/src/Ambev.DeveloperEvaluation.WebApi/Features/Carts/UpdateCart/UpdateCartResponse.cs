using Ambev.DeveloperEvaluation.Application.Common.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IReadOnlyList<CartItemDto> Items { get; set; } = [];
}
