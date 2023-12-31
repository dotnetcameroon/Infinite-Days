using app.Repositories;
using models;

namespace app.Services;

public class ProductService(IProductsRepository productsRepository)
{
    private readonly IProductsRepository _productsRepository = productsRepository;
    
    public IReadOnlyCollection<Product> GetAll()
    {
        return _productsRepository.GetAll();
    }
    public Product? GetById(int Id)
    {
        return _productsRepository.GetById(Id);
    }
}
