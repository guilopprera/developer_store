using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    public GetProductHandler(IProductRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken ct)
    {
        try
        {
            var entity = await _repo.GetByIdAsync(request.Id, ct);

            return _mapper.Map<GetProductResult>(entity);
        }
        catch
        {
            throw new InvalidOperationException("Product not found");
        }
    }
}
