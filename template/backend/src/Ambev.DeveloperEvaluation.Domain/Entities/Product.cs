using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Category { get; private set; } = string.Empty;
    public string Image { get; private set; } = string.Empty;

    public ProductRating Rating { get; private set; } = new(0, 0);

    protected Product() { }

    public Product(string title, decimal price, string description, string category, string image, ProductRating rating)
    {
        Update(title, price, description, category, image, rating);
    }

    public void Update(string title, decimal price, string description, string category, string image, ProductRating rating)
    {
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
        Rating = rating ?? new ProductRating(0, 0);
    }
}

public class ProductRating
{
    public double Rate { get; private set; }
    public int Count { get; private set; }

    protected ProductRating() { }
    public ProductRating(double rate, int count)
    {
        Rate = rate;
        Count = count;
    }
}
