using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<bool> DeleteMissingRelationsFromRequestAsync(Profile entityFromRequest, bool save);
    }
}
