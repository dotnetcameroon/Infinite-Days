using app.Repositories;
using models;

namespace app.Services;

public sealed class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        _orderRepository.OrderProcessed += HandleOrderProcessed;
    }

    public Task ProcessOrderAsync(int orderId)
    {
        // Asynchronously process the order
        // Simulates a long CPU bound calculation
        // TODO: Retrieve the order with the corresponding Id from the repository
        Thread.Sleep(1400);
        // TODO: Change the status of this order
        throw new NotImplementedException();
    }

    private void HandleOrderProcessed(Order order)
    {
        // Notify the user that an order has been processed
        // TODO: Write the order informations to the console
        throw new NotImplementedException();
    }
}
