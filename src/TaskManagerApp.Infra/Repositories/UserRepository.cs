using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}