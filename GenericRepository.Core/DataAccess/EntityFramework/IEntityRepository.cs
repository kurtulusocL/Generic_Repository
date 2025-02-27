using System.Linq.Expressions;
using GenericRepository.Core.Entities.Abstract;

namespace GenericRepository.Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includedProperties);
        Task<IEnumerable<T>> GetAllIncludingAsync(string includedProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}