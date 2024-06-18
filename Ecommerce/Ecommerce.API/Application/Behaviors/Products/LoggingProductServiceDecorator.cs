using Ecommerce.API.Application.Products;
using Ecommerce.Domain.Products;

namespace Ecommerce.API.Application.Behaviors.Products;

public class LoggingProductServiceDecorator(IProductService decoratedProductService, 
                                            ILogger<LoggingProductServiceDecorator> logger) : IProductService
{
    public async Task<int> AddProduct(Product product)
    {
        logger.LogInformation($"Start insert {product.Name} with info {product.Description}", product);

        var productId = await decoratedProductService.AddProduct(product);

        logger.LogInformation($"Insert {product.Name} success!", product);

        return productId;
    }
}
