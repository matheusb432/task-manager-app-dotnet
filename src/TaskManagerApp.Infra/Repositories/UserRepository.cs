using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskManagerContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
            // TODO test if can be translated to SQL, else if would be x.Email.ToLower() == email.ToLower()
            => await _dbSet.FirstOrDefaultAsync(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase));

        public async Task<User?> GetByUserNameAsync(string userName)
            => await _dbSet.FirstOrDefaultAsync(x => string.Equals(x.UserName, userName, StringComparison.OrdinalIgnoreCase));

        public async Task<bool> CanCreateUser(User user)
        {
            var emailExists = await _dbSet.AnyAsync(x => string.Equals(x.Email, user.Email, StringComparison.OrdinalIgnoreCase));
            var userNameExists = await _dbSet.AnyAsync(x => string.Equals(x.UserName, user.UserName, StringComparison.OrdinalIgnoreCase));

            return !emailExists && !userNameExists;
        }

        public async Task<bool> EmailExists(string email)
            => await _dbSet.AnyAsync(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase));

        public async Task<bool> UserNameExists(string userName)
            => await _dbSet.AnyAsync(x => string.Equals(x.UserName, userName, StringComparison.OrdinalIgnoreCase));
    }
}