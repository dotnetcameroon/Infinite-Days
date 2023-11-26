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
        var productService = sp.GetRequiredService<ProductService>();
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
                Display.WriteError("Enter a valid Id. Retry after 1s ...");
                Thread.Sleep(1000);
                continue;
            }

            var product = productService.GetById(productId);
            if(product is null)
            {
                Display.WriteError($"The product {productId} does not exist in the database. Retry after 1s ...");
                Thread.Sleep(1000);
                continue;
            }

            order.AddProduct(product);
        }

        orderService.RegisterOrder(order);
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
