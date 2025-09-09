using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly ICartRepository _repo;
    private readonly IMapper _mapper;
    public GetCartHandler(ICartRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken ct)
    {
        try
        {
            var entity = await _repo.GetByIdAsync(request.Id, ct);

            return _mapper.Map<GetCartResult>(entity);
        }
        catch
        {
            throw new InvalidOperationException("Cart not found");
        }
    }

}