﻿using System.Linq.Expressions;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();

        IQueryable<T> SelectQuery(Expression<Func<T, T>> selector);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);

        Task<T?> GetByIdMinimalAsync(long id);

        Task<bool> ExistsAsync(long id);

        Task<List<T>> GetManyByIdsAsync(List<int> ids);

        Task<T> InsertAsync(T entity, bool save = true);

        Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities, bool save = true);

        Task<T> UpdateAsync(T entity, bool save = true);

        Task<T> PatchAsync(T entity, bool save = true);

        Task<T> PatchPropsAsync(T entity, params Expression<Func<T, object>>[] propertyExpressions);

        Task DeleteAsync(T entity, bool save = true);

        Task DeleteAllAsync(IEnumerable<T> entities, bool save = true);

        Task SaveChangesAsync();

        void SetPropsToModified(T entity, params Expression<Func<T, object>>[] propertyExpressions);
    }
}
