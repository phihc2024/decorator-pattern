using Ecommerce.Domain.Seedwork;

namespace Ecommerce.Domain.Products;
public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);
}
