using app.Repositories;
using InfrastructureTests.Fakers;
using lib.Repositories;
using models;
using Moq;

namespace InfrastructureTests.Tests;

public class OrderRepositoryTests
{
    private readonly Mock<IOrderRepository> mockRepository;
    private readonly List<Order> expectedOrders;

    public OrderRepositoryTests()
    {
        mockRepository = new Mock<IOrderRepository>();
        Order order = new() { Id = 1, TotalPrice = 10200 };
        order.AddProducts(new List<Product> { new Product { Id = 1, Name = "Laptop", Price = 10000 }, new Product { Id = 2, Name = "Mouse", Price = 200 } });
        Order order1 = new() { Id = 1, TotalPrice = 3000 };
        order1.AddProducts(new List<Product> { new Product { Id = 3, Name = "Keyboard", Price = 3000 } });

        expectedOrders = new List<Order>
            {
              order,order1};
    }
    [Fact]
    public void GetAll_ShouldReturnAllOrders()
    {


        // Act
        mockRepository.Setup(m => m.GetAll()).Returns(expectedOrders);
        var actualOrders = mockRepository.Object.GetAll();

        // Assert
        Assert.Equal(expectedOrders, actualOrders);
    }

    [Fact]
    public void Add_ShouldAddOrdersToTheDatabase()
    {
        var order = new Order { Id = 3, TotalPrice = 200 };
        order.AddProducts(new List<Product> { new Product { Id = 4, Name = "Monitor", Price = 200 } });
        mockRepository.Setup(m => m.Add(order)).Callback(() => expectedOrders.Add(order));

        mockRepository.Object.Add(order);

        Assert.Contains(order, expectedOrders);

        Assert.False(order.Processed);
    }

    [Fact]
    public void GetById_ShouldReturnOrderWithMatchingId()
    {
        // Arrange
        mockRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => expectedOrders.Find(o => o.Id == id));

        var result1 = mockRepository.Object.GetById(1);

        Assert.Equal(expectedOrders[0], result1);

        var result2 = mockRepository.Object.GetById(1000);

        Assert.Null(result2);
    }



    //[Fact]
    //public async Task Add_ShouldRaiseTheOrderProcessedEvent()
    //{
    //    // Arrange
    //    bool isHandled = false;

    //    mockRepository.Object.OrderProcessed += _ => isHandled = true;
    //    var order = new Order();

    //    // Act
    //    mockRepository.Object.Add(order);

    //    await Task.Delay(10000); // Wait for the event to be handled

    //    // Assert
    //    Assert.True(isHandled);
    //}

    static List<Order> GenerateRandomOrders(int number)
    {
        return new OrderFaker().Generate(number);
    }
}
