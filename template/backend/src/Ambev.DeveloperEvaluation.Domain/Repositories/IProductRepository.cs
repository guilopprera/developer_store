using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<(IReadOnlyList<Product> Items, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct);
    Task<Product> CreateAsync(Product product, CancellationToken ct);
    Task UpdateAsync(Product product, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
}
