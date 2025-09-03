using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken ct)
    {
        try
        {
            var validation = await new UpdateProductValidator().ValidateAsync(request, ct);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var entity = await _repo.GetByIdAsync(request.Id, ct) ?? throw new InvalidOperationException("Product not found");

            entity.Update(request.Title, request.Price, request.Description, request.Category, request.Image,
                new Domain.Entities.ProductRating(request.RatingRate, request.RatingCount));

            await _repo.UpdateAsync(entity, ct);

            return _mapper.Map<UpdateProductResult>(entity);
        }
        catch
        {
            throw new InvalidOperationException("Error updating product");
        }
    }
}
