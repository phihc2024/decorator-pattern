using Ecommerce.Domain.Products;

namespace Ecommerce.API.Application.Products;

public interface IProductService
{
    Task<int> AddProduct(Product product);
}
