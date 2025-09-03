﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;

    public List<UpdateSaleItemDto> Items { get; set; } = new();
}

public class UpdateSaleItemDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty; 
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
