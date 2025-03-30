using CareFlow.Data.Entities;
using CareFlow.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T:BaseEntity;
        Task<int> Complete();
    }
}
