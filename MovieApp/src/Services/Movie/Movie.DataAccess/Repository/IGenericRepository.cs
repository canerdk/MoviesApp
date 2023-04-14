using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Movie.DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
    }
}
