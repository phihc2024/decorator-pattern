using Ecommerce.Domain.Products;

namespace Ecommerce.API.Application.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<int> AddProduct(Product product)
    {
        var productEntity = productRepository.Add(product);
        await productRepository.UnitOfWork.SaveChangesAsync();
        return productEntity.ProductId;
    }
}
