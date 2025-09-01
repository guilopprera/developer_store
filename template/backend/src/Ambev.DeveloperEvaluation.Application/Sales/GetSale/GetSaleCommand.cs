using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale by its ID.
/// </summary>

public class GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// Command for retrieving a sale by sale number
    /// </summary>
    public Guid Id { get; set; }

    //public GetSaleCommand() { } testar Migrations sem esse construtor

    public GetSaleCommand(Guid id)
    {
        Id = id;
    }
}

