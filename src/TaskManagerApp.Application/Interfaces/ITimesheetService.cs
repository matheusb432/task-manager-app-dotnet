using TaskManagerApp.Application.Dtos.Timesheet;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
{
    public interface ITimesheetService
    {
        OperationResult Query();

        Task<OperationResult> Insert(TimesheetPostDto viewModel);

        Task<OperationResult> Update(int id, TimesheetPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}