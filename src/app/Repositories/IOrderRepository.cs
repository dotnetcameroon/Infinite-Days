using models;

namespace app.Repositories;

public interface IOrderRepository
{
    event Action<Order> OrderProcessed;
    Order? Add(Order order);
    Order? GetById(int id);
    IReadOnlyCollection<Order> GetAll();
}
