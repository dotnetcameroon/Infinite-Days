using app.Repositories;
using models;

namespace lib.Repositories.Concrete;

internal class ProductsRepository(IEnumerable<Product> products)
    : IProductsRepository
{
    private readonly List<Product> _products = products.ToList();

    public IReadOnlyCollection<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int Id)
    {
        return _products.FirstOrDefault(p=>p.Id.Equals(Id));
    }
}
