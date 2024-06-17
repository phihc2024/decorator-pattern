namespace Ecommerce.Domain.Seedwork;
public interface IRepository<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
}

