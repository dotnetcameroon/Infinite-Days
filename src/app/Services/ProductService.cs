using app.Repositories;
using models;

namespace app.Services;

public class ProductService
{
    private readonly IProductsRepository _productsRepository;

    // Constructeur pour injecter le repository nécessaire lors de la création d'une instance de ProductService.
    public ProductService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
    
    public IReadOnlyCollection<Product> GetAll()
    {
        return _productsRepository.GetAll();
    }
    public Product? GetById(int Id)
    {
        return _productsRepository.GetById(Id);
    }
    public void AddProduct(Product product)
    {
        _productsRepository.Add(product);
    }

    public void DeleteProduct(int id)
    {
        _productsRepository.Delete(id);
    }
}
