using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}