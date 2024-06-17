using Ecommerce.Domain.Products;
using Ecommerce.Infrastructure.Options;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure;
public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbAppContext(configuration);
        services.AddRepositories();
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

    }
    private static void AddDbAppContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var databaseMySqlOptions = configuration
                                        .GetSection(MySQLOptions.GetSectionName())
                                        .Get<MySQLOptions>();

            options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);
            });

            options.EnableSensitiveDataLogging();
        });
    }
}