using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public sealed class CancelSaleHandler : IRequestHandler<CancelSaleCommand, Unit>
{
    private readonly ISaleRepository _repo;

    public CancelSaleHandler(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(CancelSaleCommand command, CancellationToken ct)
    {
        var validator = new CancelSaleCommandValidator();
        var validation = await validator.ValidateAsync(command, ct);
        if (!validation.IsValid) throw new ValidationException(validation.Errors);

        var sale = await _repo.GetByIdAsync(command.Id, ct)
                   ?? throw new KeyNotFoundException($"Sale with Id {command.Id} not found");

        sale.Cancel();
        await _repo.UpdateAsync(sale, ct);

        return Unit.Value;
    }
}
