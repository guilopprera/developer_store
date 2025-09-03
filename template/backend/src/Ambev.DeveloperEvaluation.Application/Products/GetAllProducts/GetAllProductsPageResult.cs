using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsPageResult
{
    public GetAllProductsPageResult(IReadOnlyList<GetAllProductsResult> products, int totalItems, int currentPagem, int totalPages)
    {
        Products = products;
        TotalItems = totalItems;
        CurrentPage = currentPagem;
        TotalPages = totalPages;

    }
    public IReadOnlyList<GetAllProductsResult> Products { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

}
