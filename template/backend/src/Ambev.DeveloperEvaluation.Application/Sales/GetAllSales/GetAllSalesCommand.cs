using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
    public int Page { get; set; }
    public int Size { get; set; }

    public GetAllSalesCommand() { }

    public GetAllSalesCommand(int page, int size)
    {
        Page = page;
        Size = size;
    }
}
