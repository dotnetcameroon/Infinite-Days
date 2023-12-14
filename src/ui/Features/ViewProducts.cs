using app.Services;
using Microsoft.Extensions.DependencyInjection;
using models;
using ui.Utilities;

namespace ui.Features;

internal static partial class Feature
{
    private static void DisplayProduct(Product product) 
    {
        Console.WriteLine($"Id:\t{product.Id}");
        Console.WriteLine($"Name:\t{product.Name}");
        Console.WriteLine($"Price:\t{product.Price}");
        Console.WriteLine("___________________________________________");
    }

    public static Task<bool> ViewProducts(IServiceProvider sp)
    {
        var productService = sp.GetRequiredService<ProductService>();
        var products = productService.GetAll();

        Console.WriteLine("Here is the list of all our products");
        foreach (var product in products)
        {
            DisplayProduct(product);
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

        DisplayProduct(products);



        return Task.FromResult(false);
    }

    public static Task<bool> UpdateProduct(IServiceProvider sp)
    {
        var productService = sp.GetRequiredService<ProductService>();

        Console.Write("Enter Id product: ");
        var productid = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(productid, out int id))
        {
            Display.WriteError("Enter a valid Price. Retry after 1s ...");
            Thread.Sleep(1000);
        }

        var product = productService.GetById(id);

        DisplayProduct(product);

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
        var issuc = productService.Update(product1);

        if (issuc)
            Console.WriteLine("Success");
        else
            Console.WriteLine("Echec");



        return Task.FromResult(false);
    }
}
