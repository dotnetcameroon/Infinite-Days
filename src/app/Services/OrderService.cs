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

    public async Task ProcessOrderAsync(int orderId)
    {
        var order = _orderRepository.GetById(orderId);

        if (order is not null)
        {
            order.ChangeOrderStatus(true);
            _orderRepository.OrderProcessed += HandleOrderProcessed;
        }
        
    }

    private void HandleOrderProcessed(Order order)
    {
        Console.WriteLine($"Order processed: {order.Id}, {order.Processed}, Total Price: {order.TotalPrice}");
    }
}
