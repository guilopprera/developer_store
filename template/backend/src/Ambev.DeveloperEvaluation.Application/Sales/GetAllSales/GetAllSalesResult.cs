using Ambev.DeveloperEvaluation.Application.Common.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesResult
{
    public Guid Id { get; init; }
    public string SaleNumber { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public string Branch { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
    public bool Cancelled { get; init; }
    public List<SaleItemDto> Items { get; init; } = new();
}
