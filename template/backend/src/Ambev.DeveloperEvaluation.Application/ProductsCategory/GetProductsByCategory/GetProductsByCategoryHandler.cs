using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;

public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryCommand, GetProductsByCategoryPageResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    public GetProductsByCategoryHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<GetProductsByCategoryPageResult> Handle(GetProductsByCategoryCommand request, CancellationToken ct)
    {
        try
        {
            var (items, total) = await _repo.GetByCategoryAsync(request.Category, request.Page, request.Size, request.Order, ct);
            var data = _mapper.Map<List<GetProductsByCategoryResult>>(items);

            var totalPages = (int)Math.Ceiling(total / (double)request.Size);

            return new GetProductsByCategoryPageResult(data, total, request.Page, totalPages);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving products by category");
        }
    }
}
