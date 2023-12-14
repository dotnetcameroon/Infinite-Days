using app.Repositories;
using models;

namespace lib.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];
    public event Action<Order> OrderProcessed;

    #pragma warning disable CS8618
    public OrderRepository()
    {
    }

    public OrderRepository(IEnumerable<Order> orders)
    {
        _orders = orders.ToList();
    }
    #pragma warning restore CS8618

    public IReadOnlyCollection<Order> GetAll()
    {
        // TODO: Implement the logic that returns all the registered orders
        // ANSWER
        return _orders.AsReadOnly();
    }

    public Order? GetById(int id)
    {
        // TODO: Return the first or default order that matches the id
        // ANSWER
        if (id <= 0) { return null; }

        var orderToReTurn = _orders.FirstOrDefault(o => o.Id == id);
        if(orderToReTurn == null) { return null; } else { return orderToReTurn; }
    }

    public void Add(Order order)
    {
        // TODO: Add the logic to processed the order and save it into the list of orders
        // ANSWER
        if (_orders.Any(o => o.Id == order.Id)) { return; }
        _orders.Add(order);
        OrderProcessed?.Invoke(order);
    }
}
