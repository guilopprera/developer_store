namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}

public class CreateSaleItemRequest
{
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
