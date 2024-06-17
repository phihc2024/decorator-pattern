using Ecommerce.Domain.Products;
using Ecommerce.Domain.Seedwork;

namespace Ecommerce.Infrastructure.Repositories;
public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public IUnitOfWork UnitOfWork => context;

    public Product Add(Product product)
    {
        return context.Products
               .Add(product)
               .Entity;
    }
}
