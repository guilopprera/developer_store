using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _repo;
    private readonly IMapper _mapper;

    public UpdateCartHandler(ICartRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken ct)
    {
        try
        {
            var cart = await _repo.GetByIdAsync(request.Id, ct);
            if (cart is null) throw new KeyNotFoundException("Cart not found");

            var incoming = request.Items
                .GroupBy(i => i.ProductId)
                .ToDictionary(g => g.Key, g => g.First().Quantity);

            foreach (var existing in cart.Items.ToList())
            {
                if (!incoming.ContainsKey(existing.ProductId))
                    cart.RemoveItem(existing.ProductId);
            }

            foreach (var (productId, qty) in incoming)
            {
                var already = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (already is null)
                    cart.AddItem(productId, qty);
                else
                    cart.UpdateItem(productId, qty);
            }

            cart.SetDate(request.Date);

            await _repo.UpdateAsync(cart, ct);

            return _mapper.Map<UpdateCartResult>(cart);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error updating cart", ex);
        }
    }
}
