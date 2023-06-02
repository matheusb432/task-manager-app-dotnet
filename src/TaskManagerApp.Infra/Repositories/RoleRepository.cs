using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(TaskManagerContext context) : base(context) { }

        public override IQueryable<Role> Query() => _dbSet.AsQueryable().AsSplitQuery();

        public override async Task SaveChangesAsync()
        {
            await _context.SaveChangesWithoutUserTrackingAsync();
        }
    }
}
