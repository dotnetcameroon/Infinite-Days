using app.Repositories;
using app.Services;
using InfrastructureTests.Fakers;
using Moq;

namespace ApplicationTests.Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task RegisterOrder_ShouldProcessTheSpecifiedOrder()
    {
        // Arrange
        var order = new OrderFaker().Generate(1)[0];
        var moqOrderRepository = new Mock<IOrderRepository>();
        moqOrderRepository.Setup(x => x.GetById(order.Id)).Returns(order);
        moqOrderRepository.Setup(x => x.Add(order));
        var orderRepository = moqOrderRepository.Object;

        var orderService = new OrderService(orderRepository);

        // Act
        orderService.RegisterOrder(order);
        await orderService.ProcessOrderAsync(order.Id);

        // Assert
        Assert.True(order.Processed);
    }
}
