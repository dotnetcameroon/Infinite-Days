using models;

namespace app.Repositories;

public interface IOrderRepository
{
    event Action<Order> OrderProcessed;
    void RegisterOrder(Order order);
    Order? GetSingleOrder(Func<Order, bool> predicate);
}
