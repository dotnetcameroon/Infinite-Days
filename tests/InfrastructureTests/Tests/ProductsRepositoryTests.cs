using models;
using lib.Repositories.Concrete;
using InfrastructureTests.Fakers;
using app.Repositories;
using lib.Data;
using Moq;

namespace InfrastructureTests.Tests;
public class ProductsRepositoryTests()
{

    [Fact]
    public void GetAll_ShouldReturnAllProducts()
    {
        // Arrange
        var mockProductsRepository = new Mock<IProductsRepository>();
        var products = new List<Product> { new Product(), new Product() };
        mockProductsRepository
            .Setup(repo => repo.GetAll())
            .Returns(products);

        var actualProducts = mockProductsRepository.Object.GetAll();

        // Act
       // var actualProducts = productsRepository.GetAll();

        // Assert
        Assert.Equal(products.Count, actualProducts.Count);
        Assert.Equal(products, actualProducts);
    }

    [Fact]
    public void GetById_ShouldReturnProductWithMatchingId()
    {
        // Arrange
        var mockProductsRepository = new Mock<IProductsRepository>();
        var product = new Product { Id = 1 };
        mockProductsRepository
            .Setup(repo => repo.GetById(1))
            .Returns(product);

        // Act
        var actualProduct = mockProductsRepository.Object.GetById(product.Id);

        // Assert
        Assert.Equal(product, actualProduct);
    }

}
