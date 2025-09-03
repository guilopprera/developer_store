using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context) => _context = context;

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<(IReadOnlyList<Product> Products, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct)
    {
        IQueryable<Product> products = _context.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            foreach (var part in order.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var seg = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var field = seg[0].ToLowerInvariant();
                var desc = seg.Length > 1 && seg[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                products = (field) switch
                {
                    "price" => desc ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price),
                    "title" => desc ? products.OrderByDescending(p => p.Title) : products.OrderBy(p => p.Title),
                    _ => products
                };
            }
        }
        else
        {
            products = products.OrderBy(p => p.Title);
        }

        var result = await products.Skip((page - 1) * size).Take(size).ToListAsync(ct);
        var total = await products.CountAsync(ct);

        return (result, total);
    }

    public async Task<IReadOnlyList<string>> GetAllCategoriesAsync(CancellationToken ct)
    {
        return await _context.Products.AsNoTracking()
            .Select(p => p.Category)
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync(ct);
    }

    public async Task<(IReadOnlyList<Product> Products, int Total)> GetByCategoryAsync(string category, int page, int size, string? order, CancellationToken ct)
    {
        var products = _context.Products
                    .AsNoTracking()
                    .Where(p => p.Category == category);


        if (!string.IsNullOrWhiteSpace(order))
        {
            foreach (var part in order.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var seg = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var field = seg[0].ToLowerInvariant();
                var desc = seg.Length > 1 && seg[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                products = (field) switch
                {
                    "price" => desc ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price),
                    "title" => desc ? products.OrderByDescending(p => p.Title) : products.OrderBy(p => p.Title),
                    _ => products
                };
            }
        }
        else
        {
            products = products.OrderBy(p => p.Title);
        }

        var total = await products.CountAsync(ct);
        var items = await products.Skip((page - 1) * size).Take(size).ToListAsync(ct);

        return (items, total);
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

    public async Task<string> DeleteAsync(Guid id, CancellationToken ct)
    {
        var entity = await GetByIdAsync(id, ct);
        if (entity is null) 
            return "Error trying to remove product";

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return "Success";
    }
}
