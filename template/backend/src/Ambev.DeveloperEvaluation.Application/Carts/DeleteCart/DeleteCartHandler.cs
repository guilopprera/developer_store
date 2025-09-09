using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _repo;

    public DeleteCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken ct)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(request, ct);

        try
        {
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _repo.DeleteAsync(request.Id, ct);

            return new DeleteCartResult { Message = "Success" };
        }
        catch
        {
            throw new InvalidOperationException("Error trying to delete cart");
        }
    }

}

