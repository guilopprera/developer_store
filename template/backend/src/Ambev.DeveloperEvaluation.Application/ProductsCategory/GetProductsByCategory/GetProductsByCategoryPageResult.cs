namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;

public class GetProductsByCategoryPageResult
{
    public GetProductsByCategoryPageResult(IReadOnlyList<GetProductsByCategoryResult> products, int totalItems, int currentPage, int totalPages)
    {
        Products = products;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

    public IReadOnlyList<GetProductsByCategoryResult> Products { get; }
    public int TotalItems { get; }
    public int CurrentPage { get; }
    public int TotalPages { get; }
}
