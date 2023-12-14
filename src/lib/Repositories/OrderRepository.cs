using app.Repositories;
using models;

namespace lib.Repositories;

public class OrderRepository : IOrderRepository
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
        return _orders.AsReadOnly();
        //throw new NotImplementedException();
    }

    public Order? GetById(int id)
    {
        // TODO: Return the first or default order that matches the id
        return _orders.Find(p => p.Id == id);
        // throw new NotImplementedException();
    }

    public void Add(Order order)
    {
        _orders.Add(order);

        OrderProcessed?.Invoke(order);
    }
}
