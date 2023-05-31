using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(TaskManagerContext context) : base(context) { }

        public override IQueryable<UserRole> Query() => _dbSet.AsQueryable().AsSplitQuery();

        public async override Task SaveChangesAsync()
        {
            await _context.SaveChangesWithoutUserTrackingAsync();
        }
    }
}
