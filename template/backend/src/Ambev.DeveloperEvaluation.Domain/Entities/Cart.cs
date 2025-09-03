using Ambev.DeveloperEvaluation.Domain.Common;

public class Cart : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime Date { get; private set; } = DateTime.UtcNow;

    private readonly List<CartItem> _items = new();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    protected Cart() { }
    public Cart(Guid userId) => UserId = userId;

    public void AddItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        var existing = _items.FirstOrDefault(i => i.ProductId == productId);

        if (existing != null)
            existing.Increase(quantity);
        else
            _items.Add(new CartItem(productId, quantity));
    }

    public void UpdateItem(Guid productId, int quantity)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId)
                   ?? throw new InvalidOperationException("Product not found");

        item.SetQuantity(quantity);
    }

    public void RemoveItem(Guid productId)
    {
        try
        {
            _items.RemoveAll(i => i.ProductId == productId);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Product removal error");
        }
    }
}

public class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    protected CartItem() { }
    public CartItem(Guid productId, int quantity)
    {
        ProductId = productId;
        SetQuantity(quantity);
    }

    public void Increase(int qty)
    {
        SetQuantity(Quantity + qty);
    }

    public void SetQuantity(int qty)
    {
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty));

        Quantity = qty;
    }
}
