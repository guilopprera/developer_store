using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents an individual product item within a sale,
/// including quantity, unit price and discount applied.
/// </summary>
public class SaleItem : BaseEntity, ISaleItem
{
    /// <summary>
    /// Identifier of the related sale.
    /// </summary>
    public Guid SaleId { get; private set; }

    /// <summary>
    /// Identifier of the product sold.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Quantity of the product sold.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Unit price of the product at the moment of the sale (snapshot).
    /// </summary>
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// Discount percentage applied (0.10 = 10%, 0.20 = 20%).
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Total amount for this item (Quantity * UnitPrice * (1 - Discount)).
    /// </summary>
    public decimal Total => Quantity * UnitPrice * (1 - Discount);

    /// <summary>
    /// get the Sale ID, SaleItem ID and Product ID as a string.
    /// </summary>
    string ISaleItem.Id => Id.ToString();
    string ISaleItem.SaleId => SaleId.ToString();
    string ISaleItem.ProductId => ProductId.ToString();

    protected SaleItem() { }

    /// <summary>
    /// Initializes a new sale item.
    /// </summary>
    /// <param name="saleId">The sale identifier.</param>
    /// <param name="productId">The product identifier.</param>
    /// <param name="unitPrice">Product unit price at the time of sale.</param>
    /// <param name="quantity">Quantity purchased.</param>
    /// <param name="discount">Discount percentage (0.10 = 10%).</param>
    public SaleItem(Guid saleId, Guid productId, decimal unitPrice, int quantity, decimal discount)
    {
        SaleId = saleId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        Discount = discount;
    }
}