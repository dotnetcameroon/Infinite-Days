global using ProductsOrder = (int OrderId, int ProductId);
using app.Repositories;
using lib.Data;
using models;
using SimpleOrder = (int Id, decimal TotalPrice);

namespace lib.Repositories;

internal class OrderRepository(IDatabaseAccessMethodes databaseAccessMethodes, IProductsRepository productsRepository) : IOrderRepository
{
    private readonly List<Order> _orders = [];
    public event Action<Order> OrderProcessed;

    #pragma warning disable CS8618


    //public OrderRepository(IEnumerable<Order> orders)
    //{
    //    _orders = orders.ToList();
    //}
    #pragma warning restore CS8618

    public IReadOnlyCollection<Order> GetAll()
    {
        string command = "select * from Orders";
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<SimpleOrder>(new(ResultType.Multiple, null, command)).Result;


        List<Order> orders = new List<Order>();
        if (result.IsSuccess)
        {
            foreach (var item in result.Results)
            {
                var products = productsRepository.GetProductByOrderId(item.Id);

                Order order  = new Order() { Id = item.Id, };
                order.TotalPrice = item.TotalPrice;
                order.AddProducts(products.ToList());
                orders.Add(order);
            }

        }
        //GetById(3);
        //Order or = new Order();
        //or.AddProducts(new List<Product>() { productsRepository.GetById(3), productsRepository.GetById(2) });
        //Add(or);
        return orders.AsReadOnly();
    }

    public Order? GetById(int id)
    {
        string command = "select * from  Orders where Id = @Id";

        var param = new { Id = id };
        var result = databaseAccessMethodes.CallDatabaseResponseAsync<SimpleOrder>(new(ResultType.Single, param, command)).Result;
        Order order = new();
        if (result.IsSuccess)
        {

            order.Id = result.Result.Id;
            order.TotalPrice = result.Result.TotalPrice;
            var products = productsRepository.GetProductByOrderId(id);

            order.AddProducts(products.ToList());

        }

        return order;

    }

    public Order? Add(Order order)
    {
        order.TotalPrice = order.Products.Sum(p => p.Price);
        var command1 = "INSERT INTO Orders (TotalPrice) VALUES (@TotalPrice); SELECT last_insert_rowid();";
        DatabaseAccessModel model1 = new(ResultType.Single, new { order.TotalPrice }, command1);


        var command2 = "INSERT INTO ProductsOrder (OrderId,ProductId) VALUES (@OrderId,@ProductId)";

        DatabaseAccessModel model2 = new(ResultType.Single, order.Products, command2);

        var resutl = databaseAccessMethodes.CallDatabasetransactionAsync<int>(model1, model2).Result;

        var orderAdd = GetById(resutl.Result);
        // TODO: Add the logic to processed the order and save it into the list of orders
        OrderProcessed?.Invoke(orderAdd);
        return orderAdd;
    }
}
