using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    public CreateProductHandler(IProductRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var v = await new CreateProductValidator().ValidateAsync(request, ct);
        if (!v.IsValid) throw new ValidationException(v.Errors);

        var entity = _mapper.Map<Domain.Entities.Product>(request);
        entity = await _repo.CreateAsync(entity, ct);
        return _mapper.Map<CreateProductResult>(entity);
    }
}
