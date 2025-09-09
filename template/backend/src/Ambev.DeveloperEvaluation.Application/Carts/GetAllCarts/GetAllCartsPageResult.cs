namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetAllCartsPageResult
{
    public GetAllCartsPageResult(IReadOnlyList<GetAllCartsResult> carts, int totalItems, int currentPage, int totalPages)
    {
        Carts = carts;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

    public IReadOnlyList<GetAllCartsResult> Carts { get; init; }
    public int TotalItems { get; init; }
    public int CurrentPage { get; init; }
    public int TotalPages { get; init; }
}
