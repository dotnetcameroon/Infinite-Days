using app.Repositories;
using models;

namespace lib.Repositories.Concrete;

internal class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products = [];
    public IEnumerable<Product> GetAllProducts()
    {
        // TODO: Return all the products from the list
        throw new NotImplementedException();
    }

    public Product? GetProductById(int Id)
    {
        // TODO: Retrieve a single order or default from the _products database by its Id
        throw new NotImplementedException();
    }
}
