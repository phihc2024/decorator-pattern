using Ecommerce.API.Application.Products;
using Ecommerce.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Endpoints.Products;

public static class ProductEndpointExtensions
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/product", async ([FromBody] Product product, IProductService productService) =>
        {
            var result = await productService.AddProduct(product);
            return result;
        })
        .WithName("Product")
        .WithOpenApi();
    }
}
