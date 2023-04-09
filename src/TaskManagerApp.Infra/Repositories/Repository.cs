using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.Infra.Repositories
{
    /// <summary>
    /// Abstração de repositório para permitir uma camada intermediária entre as camadas de Infra e Application
    /// </summary>
    /// <typeparam name="T">Um modelo Entity que existe em TaskManagerAppContext</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly TaskManagerContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(TaskManagerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<T?> GetByIdAsNoTrackingAsync(long id)
            => await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            await SaveChangesAsync();

            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await SaveChangesAsync();
        }

        public async Task DeleteAllAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
