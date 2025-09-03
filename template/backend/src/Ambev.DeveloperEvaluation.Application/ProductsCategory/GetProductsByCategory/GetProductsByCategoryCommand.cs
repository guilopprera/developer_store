using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;

public class GetProductsByCategoryCommand : IRequest<GetProductsByCategoryPageResult>
{
    public GetProductsByCategoryCommand(string category, int page, int size, string? order)
    {
        Category = category;
        Page = page;
        Size = size;
        Order = order;
    }

    public string Category { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }
}
