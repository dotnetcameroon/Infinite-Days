using app.Repositories;
using models;

namespace lib.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];
    #pragma warning disable CS8618
    public event Action<Order> OrderProcessed;
    #pragma warning restore CS8618

    public Order? GetSingleOrder(Func<Order, bool> predicate)
    {
        // TODO: Return the first or default order that matches the predicate
        throw new NotImplementedException();
    }

    public void RegisterOrder(Order order)
    {
        // TODO: Add the processed order to the list of orders
        OrderProcessed?.Invoke(order);
    }
}
