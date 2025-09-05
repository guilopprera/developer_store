namespace Ambev.DeveloperEvaluation.Application.Common.Sales;

public class SaleItemDto
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public string ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }
}
