using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public sealed class CancelSaleCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public CancelSaleCommand() { }
    public CancelSaleCommand(Guid id) { Id = id; }
}
