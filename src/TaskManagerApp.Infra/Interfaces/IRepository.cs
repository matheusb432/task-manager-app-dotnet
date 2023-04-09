namespace TaskManagerApp.Infra.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);

        Task<T?> GetByIdAsNoTrackingAsync(long id);

        Task<List<T>> GetManyByIdsAsync(List<int> ids);

        Task<T> InsertAsync(T entity);

        Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAllAsync(IEnumerable<T> entities);
    }
}