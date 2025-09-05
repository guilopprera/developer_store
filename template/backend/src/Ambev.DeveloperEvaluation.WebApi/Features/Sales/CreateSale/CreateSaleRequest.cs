using Ambev.DeveloperEvaluation.Application.Common.Sales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public List<SaleItemDto> Items { get; set; } = new();
}