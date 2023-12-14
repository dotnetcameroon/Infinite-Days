namespace models;

public sealed class Order
{
    private static int _count = 0;
    private readonly List<Product> _products = [];
    public int Id { get; set; } 
    public bool Processed { get; private set; }
    public IReadOnlyList<Product> Products => _products.ToArray();
    public decimal TotalPrice { get; set; }

    public void AddProduct(Product product)
    {
        _products.Add(product);

    }

    public void AddProducts(List<Product> products)
    {
        _products.AddRange(products);

    }

    public void RemoveProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }

    public void ChangeOrderStatus(bool status)
    {
        Processed = status;
    }
}
