using app.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ui.Features;

internal static partial class Feature
{
    public static Task<bool> ViewProducts(IServiceProvider sp)
    {
        var productService = sp.GetRequiredService<ProductService>();
        var products = productService.GetAll();

        Console.WriteLine("Here is the list of all our products");
        foreach (var product in products)
        {
            Console.WriteLine($"Id:\t{product.Id}");
            Console.WriteLine($"Name:\t{product.Name}");
            Console.WriteLine($"Price:\t{product.Price}");
            Console.WriteLine("___________________________________________");
        }

        return Task.FromResult(false);
    }
}
