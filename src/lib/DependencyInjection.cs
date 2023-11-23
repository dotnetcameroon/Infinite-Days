using app.Repositories;
using lib.Repositories;
using lib.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace lib;

public static class DependencyInjection
{
    public static IServiceCollection RegisterLib(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        return services;
    }
}
