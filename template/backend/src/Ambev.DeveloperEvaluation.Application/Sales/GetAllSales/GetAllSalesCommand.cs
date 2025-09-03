using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesCommand : IRequest<GetAllSalesPageResult>
{
    public GetAllSalesCommand(int page, int size, string? order)
    {
        Page = page;
        Size = size;
        Order = order;
    }

    public int Page { get; set; }
    public int Size { get; set; }
    public string? Order { get; set; }
}
