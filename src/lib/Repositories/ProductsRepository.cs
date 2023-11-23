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

    public IEnumerable<Product> GetProducts(Predicate<Product> predicate)
    {
        // TODO: Use Linq to retrieve only the products that match the predicate criteria
        throw new NotImplementedException();
    }
}
