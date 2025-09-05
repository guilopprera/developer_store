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
            var res = _mapper.Map<GetProductResult>(entity);

            if (res == null)
                throw new InvalidOperationException("Product not found");

            return res;
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException("Error trying to find product", ex);
        }
    }
}
