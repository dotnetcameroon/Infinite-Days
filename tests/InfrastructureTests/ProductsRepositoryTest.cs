using models;
using lib.Repositories.Concrete;
using InfrastructureTests.Fakers;

namespace InfrastructureTests;
public class ProductsRepositoryTests
{
    [Fact]
    public void GetAll_ShouldReturnAllProducts()
    {
        // Arrange
        IReadOnlyList<Product> expectedProducts = GenerateRandomProducts(200);
        ProductsRepository productsRepository = new (expectedProducts);

        // Act
        var actualProducts = productsRepository.GetAll();

        // Assert
        Assert.Equal(expectedProducts.Count, actualProducts.Count);
        Assert.Equal(expectedProducts, actualProducts);
    }

    [Fact]
    public void GetById_ShouldReturnProductWithMatchingId()
    {
        // Arrange
        IReadOnlyList<Product> products = GenerateRandomProducts(200);
        ProductsRepository productsRepository = new (products);
        var expectedProduct = products[Random.Shared.Next(products.Count)];

        // Act
        var actualProduct = productsRepository.GetById(expectedProduct.Id);

        // Assert
        Assert.Equal(expectedProduct, actualProduct);
    }

    [Fact]
    public void Products_ShouldHaveUniqueId()
    {
        // Arrange
        IReadOnlyList<Product> products = GenerateRandomProducts(20);
        ProductsRepository productsRepository = new (products);

        // Act
        var actualProducts = productsRepository.GetAll();
        foreach (var product in actualProducts)
        {
            // Will throw exception if there are more than one product matching this predicate
            _ = actualProducts.Single(p => p.Id == product.Id);
        }

        Assert.True(true);
    }

    static List<Product> GenerateRandomProducts(int number)
    {
        return new ProductFaker().Generate(number);
    }
}
