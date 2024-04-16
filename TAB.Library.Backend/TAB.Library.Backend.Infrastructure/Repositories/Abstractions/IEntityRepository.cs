using System.Linq.Expressions;
using TAB.Library.Backend.Core.Models;

namespace TAB.Library.Backend.Infrastructure.Repositories.Abstractions
{
    public interface IEntityRepository<TEntity>
    {
        Task<TEntity?> GetAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetToEditAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetToEditAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetListToEditAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetListToEditAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<PaginatedList<TEntity>> GetPaginatedListAsync(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes);
        Task<PaginatedList<TEntity>> GetPaginatedListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<bool> SaveChangesAsync();
    }
}
