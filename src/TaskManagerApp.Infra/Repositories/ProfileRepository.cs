using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(TaskManagerContext context) : base(context) { }

        public async Task<bool> DeleteMissingRelationsFromRequestAsync(
            Profile entityFromRequest,
            bool save
        )
        {
            var entityFromDb = await Query()
                .Include(x => x.ProfilePresetTaskItems)
                .Select(
                    x =>
                        new Profile
                        {
                            Id = x.Id,
                            ProfilePresetTaskItems = x.ProfilePresetTaskItems
                                .Select(y => new ProfilePresetTaskItem() { Id = y.Id })
                                .ToList(),
                        }
                )
                .FirstOrDefaultAsync(x => x.Id == entityFromRequest.Id);

            if (entityFromDb is null)
                return false;

            MarkRelationsForDelete(entityFromDb, entityFromRequest, e => e.ProfilePresetTaskItems);

            if (save)
                await SaveChangesAsync();

            return true;
        }
    }
}
