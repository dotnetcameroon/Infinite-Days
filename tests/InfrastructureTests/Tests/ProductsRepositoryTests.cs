using models;
using lib.Repositories.Concrete;
using InfrastructureTests.Fakers;
using app.Repositories;
using lib.Data;
using Moq;

namespace InfrastructureTests.Tests;
public class ProductsRepositoryTests
{
    private readonly Mock<IProductsRepository> mockRepository;
    private readonly List<Product> products;

    public ProductsRepositoryTests()
    {
        mockRepository = new Mock<IProductsRepository>();
        products = new List<Product>
            {
                new Product { Id = 1, Name = "product4", Price = 100000 },
                new Product { Id = 2, Name = "product5", Price = 20000 },
                new Product { Id = 3, Name = "product6", Price = 30000 }
            };
    }

    [Fact]
    public void GetAll_ShouldReturnAllProducts()
    {
        // Arrange
        mockRepository.Setup(m => m.GetAll()).Returns(products);

        // Act
        var result = mockRepository.Object.GetAll();

        // Assert
        Assert.Equal(products.Count, result.Count);
        Assert.Equal(products, result);

    }

    [Fact]
    public void GetById_ShouldReturnProductWithMatchingId()
    {
        // Arrange
        mockRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => products.Find(p => p.Id == id));
        var result1 = mockRepository.Object.GetById(1);
        Assert.Equal(products[0], result1);


        // Act
        var result2 = mockRepository.Object.GetById(1000);

        // Assert
        Assert.Null(result2);
    }

    [Fact]
    public void Add_Should_Add_Product_To_Repository()
    {
        var product = new Product { Id = 10, Name = "product10", Price = 20000 };

        mockRepository.Setup(m => m.Add(product)).Callback(() => products.Add(product));

        mockRepository.Object.Add(product);

        Assert.Contains(product, products);
    }


    [Fact]
    public void Update_Should_Update_Product_In_Repository()
    {
        var product = new Product { Id = 1, Name = "product11", Price = 9000 };

        mockRepository.Setup(m => m.Update(product)).Callback(() => products[0] = product);

        mockRepository.Object.Update(product);

        Assert.Equal(product, products[0]);
    }

}
