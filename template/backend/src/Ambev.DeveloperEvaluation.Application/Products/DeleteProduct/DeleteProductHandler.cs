using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository ProductRepository)
    {
        _productRepository = ProductRepository;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        try
        {
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _productRepository.DeleteAsync(request.Id, cancellationToken);

            return new DeleteProductResponse { Success = true };
        }
        catch
        {
            throw new InvalidOperationException("Error trying to delete product");
        }

    }
}
