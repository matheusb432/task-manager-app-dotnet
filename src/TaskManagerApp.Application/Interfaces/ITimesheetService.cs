using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.Timesheet;

namespace TaskManagerApp.Application.Interfaces
{
    public interface ITimesheetService
    {
        OperationResult Query();

        Task<OperationResult> Insert(TimesheetPostViewModel viewModel);

        Task<OperationResult> Update(int id, TimesheetPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}