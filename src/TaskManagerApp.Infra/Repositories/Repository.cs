﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly TaskManagerContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly int _userId;

        public Repository(TaskManagerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _userId = _context.GetHttpContextUserId();
        }

        public virtual IQueryable<T> Query() =>
            _dbSet
                .Where(x => x.UserCreatedId == null || x.UserCreatedId == _userId)
                .AsQueryable()
                .AsSplitQuery();

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Query().ToListAsync();

        public virtual async Task<T?> GetByIdAsync(long id) =>
            await Query().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T?> GetByIdMinimalAsync(long id) =>
            await Query()
                .AsNoTracking()
                .Select(x => new T { Id = x.Id })
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<bool> ExistsAsync(long id) => await Query().AnyAsync(x => x.Id == id);

        public virtual async Task<List<T>> GetManyByIdsAsync(List<int> ids) =>
            await Query().Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<T> InsertAsync(T entity, bool save = true)
        {
            await _dbSet.AddAsync(entity);

            if (save)
                await SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities, bool save = true)
        {
            await _dbSet.AddRangeAsync(entities);

            if (save)
                await SaveChangesAsync();

            return entities;
        }

        public async Task<T> UpdateAsync(T entity, bool save = true)
        {
            _dbSet.Update(entity);

            if (save)
                await SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity, bool save = true)
        {
            _dbSet.Remove(entity);

            if (save)
                await SaveChangesAsync();
        }

        public async Task DeleteAllAsync(IEnumerable<T> entities, bool save = true)
        {
            _dbSet.RemoveRange(entities);

            if (save)
                await SaveChangesAsync();
        }

        protected void MarkRelationsForDelete<TRelatedEntity>(
            T entityFromDb,
            T entityFromRequest,
            Expression<Func<T, IEnumerable<TRelatedEntity>>> relatedEntitiesSelector
        ) where TRelatedEntity : Entity, new()
        {
            if (entityFromDb == null || entityFromRequest == null)
                return;

            var relatedEntitiesFn = relatedEntitiesSelector.Compile();
            var relatedEntities = relatedEntitiesFn(entityFromRequest);
            var existingRelatedEntities = relatedEntitiesFn(entityFromDb);

            var entityIdsToDelete = existingRelatedEntities
                .Select(x => x.Id)
                .Except(relatedEntities.Select(x => x.Id))
                .ToList();
            var entitiesToDelete = existingRelatedEntities
                .Where(x => entityIdsToDelete.Contains(x.Id))
                .ToList();

            foreach (var entityToDelete in entitiesToDelete)
            {
                _context.Entry(entityToDelete).State = EntityState.Deleted;
            }
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
