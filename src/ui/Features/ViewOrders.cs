using app.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ui.Features;

internal partial class Feature
{
    public static Task<bool> ViewOrders(IServiceProvider sp)
    {
        var orderService = sp.GetRequiredService<OrderService>();
        var products = orderService.GetAll();

        Console.WriteLine("These are all the registered orders:");
        foreach (var product in products)
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Total Price:\t{product.TotalPrice}");
            Console.WriteLine("___________________________________________");
        }

        return Task.FromResult(false);
    }
}
