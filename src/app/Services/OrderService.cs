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

    public Order RegisterOrder(Order order)
    {
        if(_orderRepository.GetById(order.Id) is null)
            _orderRepository.Add(order);

        return order;
    }

    public IReadOnlyCollection<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public Task ProcessOrderAsync(int orderId)
    {
        // Asynchronously process the order
        // Simulates a long CPU bound calculation
        // TODO: Retrieve the order with the corresponding Id from the repository
        // ANSWER
        var searchOrder = _orderRepository.GetById(orderId);
        if(searchOrder != null)
        {
            await Task.Delay(1400);
        }
        Thread.Sleep(1400);
        // TODO: Change the status of this order
        // ANSWER
        searchOrder.ChangeOrderStatus(true);
    }

    private void HandleOrderProcessed(Order order)
    {
        // Notify the user that an order has been processed
        // TODO: Write the order informations to the console
        // ANSWER
        Console.WriteLine($"Order has been processed: {order}");
    }
}
