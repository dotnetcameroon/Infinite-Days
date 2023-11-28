using InfrastructureTests.Fakers;
using lib.Repositories;
using models;

namespace InfrastructureTests.Tests;

public class OrderRepositoryTests
{
    [Fact]
    public void GetAll_ShouldReturnAllOrders()
    {
        // Arrange
        IReadOnlyList<Order> expectedOrders = GenerateRandomOrders(200);
        OrderRepository orderRepository = new(expectedOrders);

        // Act
        var actualOrders = orderRepository.GetAll();

        // Assert
        Assert.Equal(expectedOrders.Count, actualOrders.Count);
        Assert.Equal(expectedOrders, actualOrders);
    }

    [Fact]
    public void Add_ShouldAddOrdersToTheDatabase()
    {
        // Arrange
        OrderRepository orderRepository = new();
        var previousCount = orderRepository.GetAll().Count;
        var orders = GenerateRandomOrders(200);

        // Act
        foreach (var order in orders)
        {
            orderRepository.Add(order);
        }
        var currentCount = orderRepository.GetAll().Count;

        // Assert
        Assert.True(previousCount < currentCount);
        Assert.Equal(orders.Count, currentCount - previousCount);
    }

    [Fact]
    public void GetById_ShouldReturnOrderWithMatchingId()
    {
        // Arrange
        IReadOnlyList<Order> orders = GenerateRandomOrders(200);
        OrderRepository orderRepository = new (orders);
        var expectedOrder = orders[Random.Shared.Next(orders.Count)];

        // Act
        var actualOrder = orderRepository.GetById(expectedOrder.Id);

        // Assert
        Assert.Equal(expectedOrder, actualOrder);
    }

    [Fact]
    public void Products_ShouldHaveUniqueId()
    {
        // Arrange
        IReadOnlyList<Order> orders = GenerateRandomOrders(20);
        OrderRepository orderRepository = new (orders);

        // Act
        var actualOrders = orderRepository.GetAll();
        foreach (var order in actualOrders)
        {
            // Will throw exception if there are more than one product matching this predicate
            _ = actualOrders.Single(p => p.Id == order.Id);
        }

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task Add_ShouldRaiseTheOrderProcessedEvent()
    {
        // Arrange
        bool isHandled = false;
        OrderRepository orderRepository = new();
        orderRepository.OrderProcessed += _ => isHandled = true;
        var order = new Order();

        // Act
        orderRepository.Add(order);
        await Task.Delay(100); // Wait for the event to be handled

        // Assert
        Assert.True(isHandled);
    }

    static List<Order> GenerateRandomOrders(int number)
    {
        return new OrderFaker().Generate(number);
    }
}
