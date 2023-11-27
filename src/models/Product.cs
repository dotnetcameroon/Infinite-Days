namespace models;

public sealed class Product
{
    private static int _count;
    public int Id { get; private init; } = ++_count;
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(
        string name,
        decimal price)
    {
        Name = name;
        Price = price;
    }

    #pragma warning disable
    public Product()
    {
    }
}
