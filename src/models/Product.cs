namespace models;

public sealed class Product
{
    public int Id { get; set; } 
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
