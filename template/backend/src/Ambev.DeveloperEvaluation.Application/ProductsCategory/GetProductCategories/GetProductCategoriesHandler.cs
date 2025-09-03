using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductCategories;

public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesCommand, GetProductCategoriesResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    public GetProductCategoriesHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<GetProductCategoriesResult> Handle(GetProductCategoriesCommand request, CancellationToken ct)
    {
        try
        {
            var categories = await _repo.GetAllCategoriesAsync(ct);

            return new GetProductCategoriesResult(categories);
        }
        catch
        {
            throw new InvalidOperationException("Error retrieving categories");
        }
    }
}
