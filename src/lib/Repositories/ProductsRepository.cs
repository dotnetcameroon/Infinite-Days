using app.Repositories;
using models;

namespace lib.Repositories.Concrete;

public class ProductsRepository(IEnumerable<Product> products)
    : IProductsRepository
{
    private readonly List<Product> _products = products.ToList();

    public IReadOnlyCollection<Product> GetAll()
    {
        // TODO: Return all the products from the list
        return _products.AsReadOnly();
        // throw new NotImplementedException();
    }

    public Product? GetById(int Id)
    {
        // TODO: Retrieve a single product or default from the _products database by its Id
        return _products.Find(p => p.Id == Id);
        // throw new NotImplementedException();
    }

        // Implémentation de la méthode Add
        public void Add(Product product)
        {
            _products.Add(product);
        }

        // Implémentation de la méthode Delete
        public void Delete(int id)
        {
            var productToDelete = _products.Find(p => p.Id == id);
            if (productToDelete != null)
                _products.Remove(productToDelete);
        }
}
