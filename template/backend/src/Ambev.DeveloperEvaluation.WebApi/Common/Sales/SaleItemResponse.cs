namespace Ambev.DeveloperEvaluation.WebApi.Common.Sales
{
    public class SaleItemResponse
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
