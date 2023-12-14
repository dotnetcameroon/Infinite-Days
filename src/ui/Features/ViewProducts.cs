using app.Services;
using Microsoft.Extensions.DependencyInjection;
using models;
using ui.Utilities;

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
    public static Task<bool> AddProduct(IServiceProvider sp)
    {
        var productService = sp.GetRequiredService<ProductService>();

        Console.Write("Enter Price: ");
        var input = Console.ReadLine() ?? string.Empty;

        if (!decimal.TryParse(input, out decimal Price))
        {
            Display.WriteError("Enter a valid Price. Retry after 1s ...");
            Thread.Sleep(1000);
        }

        Console.Write("Enter Name: ");
        var name = Console.ReadLine() ?? string.Empty;

        Product product1 = new() { Name = name, Price = Price };
        var products = productService.Add(product1);

        Console.WriteLine("Here is  product");

            Console.WriteLine($"Id:\t{products.Id}");
            Console.WriteLine($"Name:\t{products.Name}");
            Console.WriteLine($"Price:\t{products.Price}");
            Console.WriteLine("___________________________________________");
        

        return Task.FromResult(false);
    }
}
