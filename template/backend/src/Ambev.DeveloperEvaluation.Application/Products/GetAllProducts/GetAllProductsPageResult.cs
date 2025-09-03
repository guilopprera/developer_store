namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsPageResult
{
    public GetAllProductsPageResult(IReadOnlyList<GetAllProductsResult> products, int totalItems, int currentPage, int totalPages)
    {
        Products = products;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

    public IReadOnlyList<GetAllProductsResult> Products { get; }
    public int TotalItems { get; }
    public int CurrentPage { get; }
    public int TotalPages { get; }
}
