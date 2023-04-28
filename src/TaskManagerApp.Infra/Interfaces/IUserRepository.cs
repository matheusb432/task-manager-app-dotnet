using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByUserNameAsync(string userName);

        Task<bool> CanCreateUser(User user);

        Task<bool> EmailExists(string email);

        Task<bool> UserNameExists(string userName);
    }
}