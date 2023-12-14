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
          var orderAdd =   _orderRepository.Add(order);

        return orderAdd;
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
        Console.WriteLine($" {order.Processed} Total Price: {order.TotalPrice}");
        foreach (var product in order.Products)
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Name:\t{product.Name}");
            Console.WriteLine($"Price:\t{product.Price}");
            Console.WriteLine("___________________________________________");
        }
    }
}
