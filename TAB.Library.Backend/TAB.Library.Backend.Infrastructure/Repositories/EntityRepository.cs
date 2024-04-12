using System.Linq.Expressions;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Models;
using TAB.Library.Backend.Infrastructure.Data;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace TAB.Library.Backend.Infrastructure.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly LibraryDbContext _context;

        public EntityRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            foreach (var include in includes) query = query.Include(include);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity?> GetToEditAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            foreach (var include in includes) query = query.Include(include);

            return await query.FirstOrDefaultAsync(func);
        }

        public async Task<TEntity?> GetToEditAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.FirstOrDefaultAsync(func);
        }

        public async Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetListToEditAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.Where(func).ToListAsync();
        }

        public async Task<List<TEntity>> GetListToEditAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            return await query.Where(func).ToListAsync();
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedListAsync(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            var count = query.Count();

            var list = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(list, count, pageNumber - 1, pageSize);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var include in includes) query = query.Include(include);

            var count = query.Count();

            var list = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(list, count, pageNumber - 1, pageSize);
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }
        public void Update(TEntity entity)
        {
            entity.Update();

            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities) entity.Update();

            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
