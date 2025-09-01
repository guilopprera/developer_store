using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a sales transaction in the system.
/// Contains customer info, branch, items and discount rules.
/// </summary>
public class Sale : BaseEntity, ISale
{
    /// <summary>
    /// Gets the sale number.
    /// </summary>
    public string SaleNumber { get; private set; }

    /// <summary>
    /// Date and time when the sale was created.
    /// </summary>
    public DateTime Date { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// Customer unique identifier.
    /// </summary>
    public Guid CustomerId { get; private set; }

    /// <summary>
    /// Customer name (denormalized for fast access).
    /// </summary>
    public string CustomerName { get; private set; }

    /// <summary>
    /// Branch where the sale was made.
    /// </summary>
    public string Branch { get; private set; }

    /// <summary>
    /// Total amount of the sale (sum of items with discounts applied).
    /// </summary>
    public decimal TotalAmount => Items.Sum(i => i.Total);

    /// <summary>
    /// Indicates if the sale has been cancelled.
    /// </summary>
    public bool Cancelled { get; private set; }

    private readonly List<SaleItem> _items = new();
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Gets the unique identifier of the sale as a string (from Guid).
    /// </summary>
    string ISale.Id => Id.ToString();

    /// <summary>
    /// Parameterless constructor required by Entity Framework Core
    /// to materialize the Sale entity when loading from the database.
    /// Marked as protected to prevent direct usage in application code.
    /// </summary>
    protected Sale() { }

    /// <summary>
    /// Initializes a new sale with basic customer and branch info.
    /// Generates a random SaleNumber in the format SALE-12345.
    /// </summary>
    public Sale(Guid customerId, string customerName, string branch)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        Branch = branch;

        var random = new Random();
        // Generate a random 5-digit number
        var number = random.Next(10000, 99999);
        SaleNumber = $"SALE-{number}";
    }

    /// <summary>
    /// Adds a product item to the sale, applying business discount rules:
    /// - 4 to 9 items → 10% discount
    /// - 10 to 20 items → 20% discount
    /// - Above 20 items → not allowed
    /// </summary>
    public void AddItem(Guid productId, string productName, decimal unitPrice, int quantity)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Maximum limit is 20 items per product.");

        var discount = CalculateDiscount(quantity);
        var item = new SaleItem(this.Id, productId, unitPrice, quantity, discount);
        _items.Add(item);
    }

    /// <summary>
    /// Marks the sale as cancelled.
    /// </summary>
    public void Cancel() => Cancelled = true;

    private decimal CalculateDiscount(int qty)
    {
        if (qty >= 10 && qty <= 20) return 0.20m;
        if (qty >= 4 && qty < 10) return 0.10m;
        return 0m;
    }

    public void ClearItems() => _items.Clear();

    public void ReplaceItems(IEnumerable<(Guid productId, string productName, decimal unitPrice, int quantity)> items)
    {
        _items.Clear();
        foreach (var i in items)
        {
            AddItem(i.productId, i.productName, i.unitPrice, i.quantity);
        }
    }

    public void UpdateHeader(string customerName, string branch)
    {
        CustomerName = customerName;
        Branch = branch;
    }
}