using models;

namespace app.Repositories;

public interface IProductsRepository
{
    IReadOnlyCollection<Product> GetAll();
    Product? GetById(int Id);
    IList<Product> GetProductByOrderId(int Id);

}
