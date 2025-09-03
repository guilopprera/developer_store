using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    private readonly ISaleRepository _repo;

    public CancelSaleHandler(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken ct)
    {
        try
        {
            var validator = new CancelSaleCommandValidator();
            var validation = await validator.ValidateAsync(request, ct);
            if (!validation.IsValid) throw new ValidationException(validation.Errors);

            var sale = await _repo.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException($"Sale with Id {request.Id} not found");

            sale.Cancel();
            await _repo.UpdateAsync(sale, ct);

            return new CancelSaleResult { Success = true};
        }
        catch
        {
            throw new InvalidOperationException("Error cancelling sale");
        }
    }
}
