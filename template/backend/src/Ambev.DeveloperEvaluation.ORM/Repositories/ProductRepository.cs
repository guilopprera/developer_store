using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context) => _context = context;

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<(IReadOnlyList<Product> Items, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct)
    {
        IQueryable<Product> productList = _context.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            foreach (var part in order.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var seg = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var field = seg[0].ToLowerInvariant();
                var desc = seg.Length > 1 && seg[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                productList = (field) switch
                {
                    "price" => desc ? productList.OrderByDescending(p => p.Price) : productList.OrderBy(p => p.Price),
                    "title" => desc ? productList.OrderByDescending(p => p.Title) : productList.OrderBy(p => p.Title),
                    _ => productList
                };
            }
        }
        else
        {
            productList = productList.OrderBy(p => p.Title);
        }

        var result = await productList.Skip((page - 1) * size).Take(size).ToListAsync(ct);
        var total = await productList.CountAsync(ct);

        return (result, total);
    }

    public async Task<Product> CreateAsync(Product product, CancellationToken ct)
    {
        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct);
        return product;
    }

    public async Task UpdateAsync(Product product, CancellationToken ct)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var entity = await GetByIdAsync(id, ct);
        if (entity is null) return false;
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
