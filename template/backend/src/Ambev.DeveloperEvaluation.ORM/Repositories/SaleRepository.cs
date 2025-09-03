using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<(IReadOnlyList<Sale> Items, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct)
    {
        IQueryable<Sale> salesList = _context.Sales.Include(s => s.Items).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            foreach (var part in order.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var seg = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var field = seg[0].ToLowerInvariant();
                var desc = seg.Length > 1 && seg[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                salesList = (field) switch
                {
                    "salenumber" => desc ? salesList.OrderByDescending(p => p.SaleNumber) : salesList.OrderBy(p => p.SaleNumber),
                    "date" => desc ? salesList.OrderByDescending(p => p.Date) : salesList.OrderBy(p => p.Date),
                    "customer" => desc ? salesList.OrderByDescending(p => p.CustomerName) : salesList.OrderBy(p => p.CustomerName),
                    _ => salesList
                };
            }
        }
        else
        {
            salesList = salesList.OrderByDescending(p => p.Date);
        }

        var result = await salesList.Skip((page - 1) * size).Take(size).ToListAsync(ct);
        var total = await salesList.CountAsync(ct);

        return (result, total);
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task UpdateAsync(Sale sale, CancellationToken cancellationToken)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken ct)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, ct);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
