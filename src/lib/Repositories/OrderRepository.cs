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
        return _orders.AsReadOnly();

    }

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(order => order.Id == id);

    }

    public void Add(Order order)
    {
        _orders.Add(order);

        // TODO: Add the logic to processed the order and save it into the list of orders
        OrderProcessed?.Invoke(order);
    }
}
