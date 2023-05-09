using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface ITimesheetRepository : IRepository<Timesheet>
    {
        Task<bool> DeleteMissingRelationsFromRequestAsync(Timesheet entityFromRequest, bool save);
    }
}