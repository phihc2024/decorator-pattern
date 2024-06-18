using Ecommerce.API.Application.Behaviors.Products;
using Ecommerce.API.Application.Products;
using Ecommerce.Domain.Products;
using FluentValidation;

namespace Ecommerce.API;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Product>, ProductValidator>();

        services.AddScoped<ProductService>();

        services.AddScoped<IProductService>(provider =>
        {
            var baseService = provider.GetRequiredService<ProductService>();
            var validators = provider.GetRequiredService<IEnumerable<IValidator<Product>>>();
 
            var validationDecorator = new ValidationProductServiceDecorator(baseService, validators);

            var logger = provider.GetRequiredService<ILogger<LoggingProductServiceDecorator>>();
            return new LoggingProductServiceDecorator(validationDecorator, logger);
        });
    }
}
