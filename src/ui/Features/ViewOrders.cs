using app.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ui.Features;

internal partial class Feature
{
    public static bool ViewOrders(IServiceProvider sp)
    {
        var orderRepository = sp.GetRequiredService<IOrderRepository>();
        var products = orderRepository.GetAllOrders();

        Console.WriteLine("These are all the registered orders:");
        foreach (var product in products)
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Total Price:\t{product.TotalPrice}");
            Console.WriteLine("___________________________________________");
        }

        return false;
    }
}
