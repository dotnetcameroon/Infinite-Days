namespace models;

public sealed class Order
{
    private static int _count = 0;
    private readonly List<Product> _products = [];
    public int Id { get; private init; } = ++_count;
    public bool Processed { get; private set; }
    public IReadOnlyList<Product> Products => _products.ToArray();
    public decimal TotalPrice => Products.Sum(p => p.Price);

    public void AddProduct(Product product)
    {
        // TODO: Implement the method that adds a product to this order
        // ANSWER
        if (_products.Any(p => p.Id == product.Id || p.Name == product.Name)) { return; }

        _products.Add(product);
        Console.WriteLine("Produit ajouté avec succès !");
    }

    public void RemoveProduct(int id)
    {
        // TODO: Implement the method that removes a specific product from the order based on its Id
        // ANSWER 
        if (Id <= 0) { return; }

        var productToRemove = _products.FirstOrDefault(p => p.Id == Id);
        if(productToRemove != null)
        {
            _products.Remove(productToRemove);
            Console.WriteLine("Produit supprimé avec succès !");
        }
        return;
    }

    public void ChangeOrderStatus(bool status)
    {
        Processed = status;
    }
}
