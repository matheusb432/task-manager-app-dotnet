using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class ProfileTypeRepository : Repository<ProfileType>, IProfileTypeRepository
    {
        public ProfileTypeRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}