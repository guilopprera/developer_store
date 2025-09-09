using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GertAllCartsHandler : IRequestHandler<GetAllCartsCommand, GetAllCartsPageResult>
{
    private readonly ICartRepository _repo;
    private readonly IMapper _mapper;
    public GertAllCartsHandler(ICartRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<GetAllCartsPageResult> Handle(GetAllCartsCommand request, CancellationToken ct)
    {
        try
        {
            var (items, total) = await _repo.GetAllAsync(request.Page, request.Size, request.Order, ct);
            var data = _mapper.Map<List<GetAllCartsResult>>(items);

            var totalPages = (int)Math.Ceiling(total / (double)request.Size);

            return new GetAllCartsPageResult(data, total, request.Page, totalPages);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving carts");
        }
    }

}