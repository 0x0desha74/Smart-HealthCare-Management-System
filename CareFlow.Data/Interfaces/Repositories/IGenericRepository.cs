using CareFlow.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace CareFlow.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec); 
        Task<T> GetEntityWithAsync(ISpecification<T> spec);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
