namespace models;

public class Order
{
    private readonly List<Product> _products = [];
    public int Id { get; set; }
    public IReadOnlyList<Product> Products => _products.ToArray();
    public decimal TotalPrice => Products.Sum(p => p.Price);
}
