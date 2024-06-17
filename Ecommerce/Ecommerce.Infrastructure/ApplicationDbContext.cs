using Ecommerce.Domain.Products;
using Ecommerce.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    DbContext(options), IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
}
