using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUserNameAsync(string userName);
    }
}