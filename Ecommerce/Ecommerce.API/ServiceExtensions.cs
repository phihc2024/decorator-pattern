using Ecommerce.API.Application.Products;

namespace Ecommerce.API;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}
