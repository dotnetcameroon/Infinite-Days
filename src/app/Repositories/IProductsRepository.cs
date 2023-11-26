using models;

namespace app.Repositories;

public interface IProductsRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int Id);
}
