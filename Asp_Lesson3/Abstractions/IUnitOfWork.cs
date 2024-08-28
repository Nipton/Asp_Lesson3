using Asp_Lesson3.Services;

namespace Asp_Lesson3.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ProductRepository Products { get; }
        ProductGroupRepository Groups { get; }
        StoreRepository Stores { get; }
    }
}
