using app;
using app.Services;
using lib;
using lib.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ui.Features;
using ui.Utilities;

namespace ui;

internal class Program
{
    private static readonly Dictionary<
        int, // Key
        (string featureName, Func<IServiceProvider, Task<bool>> featureAsync)> // Value
        _features = new()
    {
        { 1, ("See all products", Feature.ViewProducts) },
        { 2, ("Make an order", Feature.MakeOrder) },
        { 3, ("See all orders", Feature.ViewOrders) },
        { 4, ("Add Product", Feature.AddProduct) },
        { 5, ("Update Product", Feature.UpdateProduct) },
        { 6, ("Quit", Feature.Exit) },

    };

    private static readonly (int, string)[] _options = _features
        .Select(f => (f.Key, f.Value.featureName))
        .ToArray();

    private static async Task Main(string[] args)
    {
        IHost host = CreateHostBuilder().Build();
        using var scope = host.Services.CreateScope();
        var sp = scope.ServiceProvider;
        bool exit = false;



        var databaseInitMethodes = sp.GetRequiredService<IDatabaseInitMethodes>();

        databaseInitMethodes.InitializeDatabase();
        while (!exit)
        {
            Console.WriteLine();
            Display.PrintMenu(_options);

            int choice = Display.Read<int>(ValidateMenuInput, "\nEnter your choice: ");

            Console.Clear();

            if (_features.TryGetValue(choice, out var option))
                exit = await option.featureAsync(sp);
            else
                exit = true;
        }

        Console.Write("\nTerminated with status 0. Press any key to close . . . ");
        Console.ReadKey();
    }

    private static (bool, string) ValidateMenuInput(int arg)
    {
        return (
            arg > 0 && arg < _features.Count + 1,
            $"Choose a number between 1 and {_features.Count}. Try again: "
        );
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.RegisterApp();
                services.RegisterLib();
            });
    }
}
