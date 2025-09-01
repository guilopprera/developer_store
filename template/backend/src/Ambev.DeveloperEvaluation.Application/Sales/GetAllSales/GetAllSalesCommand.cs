using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Command to retrieve all sales with pagination.
/// </summary>
public sealed class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;

    public GetAllSalesCommand() { }

    public GetAllSalesCommand(int page, int size)
    {
        Page = page;
        Size = size;
    }
}
