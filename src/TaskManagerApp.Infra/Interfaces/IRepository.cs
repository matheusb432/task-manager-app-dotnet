namespace TaskManagerApp.Infra.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);

        Task<T?> GetByIdAsNoTrackingAsync(long id);

        Task<List<T>> GetManyByIdsAsync(List<int> ids);

        Task<T> InsertAsync(T entity, bool save = true);

        Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities, bool save = true);

        Task<T> UpdateAsync(T entity, bool save = true);

        Task DeleteAsync(T entity, bool save = true);

        Task DeleteAllAsync(IEnumerable<T> entities, bool save = true);

        Task SaveChangesAsync();
    }
}