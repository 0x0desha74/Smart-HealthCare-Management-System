using CareFlow.Core.Interfaces.Repositories;
using CareFlow.Data.Entities;

namespace CareFlow.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> Complete();
    }
}
