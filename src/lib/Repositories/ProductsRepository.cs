using app.Repositories;
using models;

namespace lib.Repositories.Concrete;

internal class ProductsRepository(IEnumerable<Product> products)
    : IProductsRepository
{
    private readonly List<Product> _products = products.ToList();

    public IReadOnlyCollection<Product> GetAll()
    {
        // TODO: Return all the products from the list
        // ANSWER
        if (_products.Count == 0) { return new List<Product>().AsReadOnly(); }          
        return _products.AsReadOnly();
    }

    public Product? GetById(int Id)
    {
        // TODO: Retrieve a single product or default from the _products database by its Id
        // ANSWER
        if (Id <= 0) { return null; }

        var productToReturn = _products.FirstOrDefault(p => p.Id == Id);
        if (productToReturn == null) { return null; }
        
        return productToReturn;
    }
}
