using app.Repositories;
using models;

namespace lib.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];
    #pragma warning disable CS8618
    public event Action<Order> OrderProcessed;
    #pragma warning restore CS8618

    public IReadOnlyCollection<Order> GetAll()
    {
        // TODO: Implement the logic that returns all the registered orders
        throw new NotImplementedException();
    }

    public Order? GetById(int id)
    {
        // TODO: Return the first or default order that matches the id
        throw new NotImplementedException();
    }

    public void Add(Order order)
    {
        // TODO: Add the logic to processed the order and save it into the list of orders
        OrderProcessed?.Invoke(order);
    }
}
