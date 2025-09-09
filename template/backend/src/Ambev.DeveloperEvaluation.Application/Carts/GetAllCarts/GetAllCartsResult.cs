using Ambev.DeveloperEvaluation.Application.Common.Carts;

public class GetAllCartsResult
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public IReadOnlyList<CartItemDto> Items { get; init; } = [];
}
