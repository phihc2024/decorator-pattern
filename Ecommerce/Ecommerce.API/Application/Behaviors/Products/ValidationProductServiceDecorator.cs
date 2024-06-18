using Ecommerce.API.Application.Products;
using Ecommerce.Domain.Products;
using FluentValidation;

namespace Ecommerce.API.Application.Behaviors.Products;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("ProductName is required.");

        RuleFor(p => p.Price)
            .NotNull()
            .WithMessage("Price is required.");

        RuleFor(p => p.StockQuantity)
            .NotNull()
            .WithMessage("StockQuantity is required.");
    }
}

public class ValidationProductServiceDecorator(
    IProductService decoratedProductService,
    IEnumerable<IValidator<Product>> validators) : IProductService
{
    public async Task<int> AddProduct(Product product)
    {
         var context = new ValidationContext<Product>(product);

        var failures = validators
                      .Select(v => v.Validate(context))
                      .SelectMany(result => result.Errors)
                      .Where(f => f != null)
                      .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        var result = await decoratedProductService.AddProduct(product);
        return result;
    }
}
