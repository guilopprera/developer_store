namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesPageResult
{
    public GetAllSalesPageResult(IReadOnlyList<GetAllSalesResult> sales, int totalItems, int currentPagem, int totalPages)
    {
        Sales = sales;
        TotalItems = totalItems;
        CurrentPage = currentPagem;
        TotalPages = totalPages;

    }
    public IReadOnlyList<GetAllSalesResult> Sales { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
