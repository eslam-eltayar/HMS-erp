using HMS.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Repositories.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T?> GetByIdWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default); // for Count all
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        IQueryable<T> GetAllAsQueryable(ISpecification<T>? spec);
        IQueryable<T> GetAllAsQueryable();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddRange(IEnumerable<T> entities);
    }
}
