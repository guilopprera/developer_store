using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsCommand : IRequest<GetAllProductsPageResult>
{
    public GetAllProductsCommand(int page, int size, string? order)
    {
        Page = page;
        Size = size;
        Order = order;
    }

    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }
}
