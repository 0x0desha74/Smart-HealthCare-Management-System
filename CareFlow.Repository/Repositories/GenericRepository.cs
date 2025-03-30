using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;
using CareFlow.Data.Interfaces;
using CareFlow.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }



        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }


        public Task<T> GetEntityWithAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }



        public async Task AddAsync(T entity)
        {
          await  _dbContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }


        public void UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
