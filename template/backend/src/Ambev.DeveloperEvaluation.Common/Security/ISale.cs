namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de uma venda no sistema.
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Gets the unique identifier of the sale.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the sale number (business identifier, formatted as SALE-12345).
        /// </summary>
        string SaleNumber { get; }

        /// <summary>
        /// Gets the customer name associated with the sale.
        /// </summary>
        string CustomerName { get; }

        /// <summary>
        /// Gets the total amount of the sale.
        /// </summary>
        decimal TotalAmount { get; }

        /// <summary>
        /// Indicates whether the sale is cancelled or not.
        /// </summary>
        bool Cancelled { get; }
    }
}
