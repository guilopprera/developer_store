namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// HTTP request body for creating a new sale.
/// </summary>
public sealed class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}

public sealed class CreateSaleItemRequest
{
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
