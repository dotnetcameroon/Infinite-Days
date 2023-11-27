using app.Services;
using Microsoft.Extensions.DependencyInjection;

namespace app;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApp(this IServiceCollection services)
    {
        services.AddScoped<OrderService>();
        services.AddScoped<ProductService>();
        return services;
    }
}
