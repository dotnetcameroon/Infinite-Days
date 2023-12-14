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
        try
    {
        // Asynchronously process the order
        await Task.Delay(1400); // Simule un traitement asynchrone

            // TODO: Retrieve the order with the corresponding Id from the repository
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Order order = _orderRepository.GetById(orderId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (order != null)
        {
            // TODO: Change the status of this order
            order.ChangeOrderStatus(true);

            // Notify that the order has been processed
            // OrderProcessed?.Invoke(order);
        }
        else
        {
            Console.WriteLine($"Order with Id {orderId} not found.");
        }
    }
    catch (Exception ex)
    {
        // Handle exceptions appropriately
        Console.WriteLine($"Error processing order: {ex.Message}");
    }
        //throw new NotImplementedException();
    }

    private void HandleOrderProcessed(Order order)
    {
        // Notify the user that an order has been processed
        Console.WriteLine($"Order {order.Id} has been processed successfully!");
        Console.WriteLine($"Total Price: {order.TotalPrice:C}");
        Console.WriteLine("Ordered Products:");
        
        foreach (var product in order.Products)
        {
            Console.WriteLine($"  - {product.Name} ({product.Price:C})");
        }

        Console.WriteLine("___________________________________________");
            // TODO: Write the order informations to the console
            //throw new NotImplementedException();
        }
}
