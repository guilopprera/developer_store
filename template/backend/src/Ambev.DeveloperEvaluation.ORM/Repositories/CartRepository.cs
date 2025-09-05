using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Carts
            //.Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<(IReadOnlyList<Cart> Carts, int Total)> GetAllAsync(int page, int size, string? order, CancellationToken ct)
    {
        IQueryable<Cart> carts = _context.Carts.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            foreach (var part in order.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var seg = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var field = seg[0].ToLowerInvariant();
                var desc = seg.Length > 1 && seg[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                carts = (field) switch
                {
                    "userid" => desc ? carts.OrderByDescending(p => p.UserId) : carts.OrderBy(p => p.UserId)
                };
            }
        }
        else
        {
            carts = carts.OrderBy(p => p.Id);
        }

        var result = await carts.Skip((page - 1) * size).Take(size).ToListAsync(ct);
        var total = await carts.CountAsync(ct);

        return (result, total);
    }

    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task UpdateAsync(Cart cart, CancellationToken cancellationToken)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<string> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return "Error trying to remove cart";

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return "Success";
    }
}
