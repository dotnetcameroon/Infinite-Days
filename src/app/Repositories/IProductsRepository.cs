using models;

namespace app.Repositories;

public interface IProductsRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int Id);
}
