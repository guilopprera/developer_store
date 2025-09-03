namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesRequest
{
    public int Page { get; init; } = 1;
    public int Size { get; init; } = 10;
}
