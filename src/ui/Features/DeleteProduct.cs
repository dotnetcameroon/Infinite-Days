using app.Services;
using Microsoft.Extensions.DependencyInjection;
using ui.Utilities;

namespace ui.Features
{
    internal static partial class Feature
    {
        // Méthode pour supprimer un produit existant.
        public static Task<bool> DeleteProduct(IServiceProvider sp)
        {
            var productService = sp.GetRequiredService<ProductService>();

            Console.Write("Enter the Id of the product you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Display.WriteError("Invalid Id. Retry after 1s ...");
                Thread.Sleep(1000);
                return Task.FromResult(false);
            }

            var existingProduct = productService.GetById(productId);
            if (existingProduct is null)
            {
                Display.WriteError($"Product with Id {productId} does not exist. Retry after 1s ...");
                Thread.Sleep(1000);
                return Task.FromResult(false);
            }

            productService.DeleteProduct(existingProduct.Id);

            Console.WriteLine($"Product with Id {productId} deleted successfully.");

            return Task.FromResult(false);
        }
    }
}
