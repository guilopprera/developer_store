namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de uma venda no sistema.
    /// </summary>
    public interface ISaleItem
    {
        /// <summary>Unique identifier of the sale item.</summary>
        string Id { get; }

        /// <summary>Identifier of the related sale.</summary>
        string SaleId { get; }

        /// <summary>Identifier of the product being sold.</summary>
        string ProductId { get; }

        /// <summary>Quantity of the product sold.</summary>
        int Quantity { get; }

        /// <summary>Unit price at the moment of sale (snapshot).</summary>
        decimal UnitPrice { get; }

        /// <summary>Discount percentage applied (0.10 = 10%).</summary>
        decimal Discount { get; }

        /// <summary>Total = Quantity * UnitPrice * (1 - Discount).</summary>
        decimal Total { get; }
    }
}
