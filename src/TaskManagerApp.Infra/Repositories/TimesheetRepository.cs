using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        public TimesheetRepository(TaskManagerContext context) : base(context)
        {
        }

        public async Task<bool> DeleteMissingRelationsFromRequestAsync(Timesheet entityFromRequest, bool save)
        {
            var entityFromDb = await _dbSet
                .AsSplitQuery()
                .Include(x => x.TimesheetNotes)
                .Include(x => x.TaskItems)
                .Select(x => new Timesheet
                {
                    Id = x.Id,
                    TimesheetNotes = x.TimesheetNotes.Select(y => new TimesheetNote() { Id = y.Id }).ToList(),
                    TaskItems = x.TaskItems.Select(y => new TaskItem() { Id = y.Id }).ToList(),
                })
                .FirstOrDefaultAsync(x => x.Id == entityFromRequest.Id);

            if (entityFromDb is null) return false;

            MarkRelationsForDelete(entityFromDb, entityFromRequest, e => e.TimesheetNotes);
            MarkRelationsForDelete(entityFromDb, entityFromRequest, e => e.TaskItems);

            if (save) await SaveChangesAsync();

            return true;
        }
    }
}