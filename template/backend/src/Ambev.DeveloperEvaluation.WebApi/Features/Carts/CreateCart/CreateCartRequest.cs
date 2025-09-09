using Ambev.DeveloperEvaluation.Application.Common.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<CartItemDto> Items { get; set; } = new();
}

