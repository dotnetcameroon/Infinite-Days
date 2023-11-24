namespace models;

public sealed class Product(
    string name,
    decimal price)
{
    private static int _count;
    public int Id { get; private init; } = ++_count;
    public string Name { get; private set; } = name;
    public decimal Price { get; private set; } = price;
}
