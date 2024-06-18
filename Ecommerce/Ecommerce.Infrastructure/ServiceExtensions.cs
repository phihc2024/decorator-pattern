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
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

    }
    public static void AddDbAppContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var databaseMySqlOptions = configuration
                                        .GetSection(MySQLOptions.GetSectionName())
                                        .Get<MySQLOptions>();
 
            options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);               
                dbOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });

            options.EnableSensitiveDataLogging();
        });
    }
}