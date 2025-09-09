using Ambev.DeveloperEvaluation.WebApi.Common.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IReadOnlyList<CartItemResponse> Items { get; set; } = [];
}