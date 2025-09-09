using Ambev.DeveloperEvaluation.Application.Common.Carts;

public class GetCartResult
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<CartItemDto> Items { get; init; } = new List<CartItemDto>();
}
