using app.Repositories;
using app.Services;
using InfrastructureTests.Fakers;
using models;
using Moq;

namespace ApplicationTests.Tests;

public class OrderServiceTests
{
    [Fact]
    public void RegisterOrder_ShouldProcessTheSpecifiedOrder()
    {
        // Arrange
        var orders = new OrderFaker().Generate(1);
        var order = orders[Random.Shared.Next(orders.Count)];
        var moqOrderRepository = new Mock<IOrderRepository>();
        moqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
        moqOrderRepository.Setup(x => x.GetById(order.Id - 1)).Returns(orders[order.Id]);
        moqOrderRepository.Setup(x => x.Add(order));

        var orderService = new OrderService(moqOrderRepository.Object);

        // Act
        orderService.RegisterOrder(order);

        // Assert
        Assert.True(order.Processed);
    }

    [Fact]
    public void ProcessOrderAsync_ShouldRaiseTheOrderProcessedEvent()
    {
        // Arrange
        var orders = new OrderFaker().Generate(1);
        var order = orders[Random.Shared.Next(orders.Count)];
        var moqOrderRepository = new Mock<IOrderRepository>();
        moqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
        moqOrderRepository.Setup(x => x.GetById(order.Id - 1)).Returns(orders[order.Id]);
        moqOrderRepository.Setup(x => x.Add(order));
        var orderRepository = moqOrderRepository.Object;
        orderRepository.OrderProcessed += HandleOrderProcessed;

        var orderService = new OrderService(orderRepository);

        orderService.RegisterOrder(order);
        Task.Run(async () => await orderService.ProcessOrderAsync(order.Id));

        // Wait for the event to be handles
        bool isHandled = false;
        Task.Delay(200);
        Assert.True(isHandled);
        void HandleOrderProcessed(Order order)
        {
            isHandled = true;
        }
    }
}
