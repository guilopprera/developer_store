namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{

    Task<(IReadOnlyList<Cart> Carts, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct);
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Cart> CreateAsync(Cart cart, CancellationToken ct);
    Task UpdateAsync(Cart cart, CancellationToken ct);
    Task<string> DeleteAsync(Guid id, CancellationToken ct);

}
