using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, GetAllProductsPageResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    public GetAllProductsHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<GetAllProductsPageResult> Handle(GetAllProductsCommand request, CancellationToken ct)
    {
        try
        {
            var (items, total) = await _repo.GetAllAsync(request.Page, request.Size, request.Order, ct);
            var data = _mapper.Map<List<GetAllProductsResult>>(items);

            var totalPages = (int)Math.Ceiling(total / (double)request.Size);

            return new GetAllProductsPageResult(data, total, request.Page, totalPages);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving products");
        }
    }

}