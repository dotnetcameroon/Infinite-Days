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

        // Add products process
        while(true)
        {
            Console.Clear();
            PrintProducts(order);
            Console.Write("Enter the Id of the product you want to add, or 'ok' to process the order");
            var input = Console.ReadLine() ?? string.Empty;
            if(input.Equals("ok", StringComparison.OrdinalIgnoreCase))
                break;

            if(!int.TryParse(input, out int productId))
            {
                Display.WriteError("Enter a valid Id");
                continue;
            }

            var product = productsRepository.GetById(productId);
            if(product is null)
            {
                Display.WriteError($"The product {productId} does not exist in the database");
                continue;
            }

            order.AddProduct(product);
        }

        // Process order
        orderRepository.Add(order);
        await orderService.ProcessOrderAsync(order.Id);
        return false;
    }

    private static void PrintProducts(Order order)
    {
        Console.WriteLine("Order Products: \n");
        foreach (var product in order.Products)
        {
            Console.WriteLine(product.Id);
        }
        Console.WriteLine();
    }
}
