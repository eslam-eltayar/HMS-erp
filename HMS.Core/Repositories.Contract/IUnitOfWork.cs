using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Repositories.Contract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        // Apply Open Closed Principle 
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);

    }
}