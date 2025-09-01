using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public sealed class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;

    public List<UpdateSaleItemDto> Items { get; set; } = new();
}

public sealed class UpdateSaleItemDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty; 
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
