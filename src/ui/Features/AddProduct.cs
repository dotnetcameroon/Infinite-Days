using app.Services;
using Microsoft.Extensions.DependencyInjection;
using models;
using ui.Utilities;

namespace ui.Features
{
    internal static partial class Feature
    {
        // Méthode pour créer un nouveau produit.
        public static Task<bool> CreateProduct(IServiceProvider sp)
        {
            var productService = sp.GetRequiredService<ProductService>();

            Console.Write("Enter the name of the new product: ");
            var name = Console.ReadLine();

            Console.Write("Enter the price of the new product: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Display.WriteError("Invalid price. Retry after 1s ...");
                Thread.Sleep(1000);
                return Task.FromResult(false);
            }

#pragma warning disable CS8604 // Possible null reference argument.
            var newProduct = new Product(name, price);
#pragma warning restore CS8604 // Possible null reference argument.
            productService.AddProduct(newProduct);

            Console.WriteLine($"New product created successfully. Id: {newProduct.Id}");
            return Task.FromResult(false);
        }
    }
}
