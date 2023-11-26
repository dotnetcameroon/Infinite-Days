using app.Repositories;
using app.Services;
using Microsoft.Extensions.DependencyInjection;
using models;
using ui.Utilities;

namespace ui.Features;

internal partial class Feature
{
    public static async Task<bool> MakeOrder(IServiceProvider sp)
    {
        var orderService = sp.GetRequiredService<OrderService>();
        var orderRepository = sp.GetRequiredService<IOrderRepository>();
        var productsRepository = sp.GetRequiredService<IProductsRepository>();
        var order = new Order();

        bool exit = false;
        // Add products process
        while(!exit)
        {
            // Add a new product
            // Or quit the process
        }

        // Process order
        await orderService.ProcessOrderAsync(order.Id);
        return false;
    }
}
