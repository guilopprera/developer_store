namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public sealed class GetAllSalesItemResult
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }
}

public sealed class GetAllSalesResult
{
    public Guid Id { get; init; }
    public string SaleNumber { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public string Branch { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
    public bool Cancelled { get; init; }
    public List<GetAllSalesItemResult> Items { get; init; } = new();
}
