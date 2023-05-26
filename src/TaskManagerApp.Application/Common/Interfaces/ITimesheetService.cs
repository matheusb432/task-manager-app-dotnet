using TaskManagerApp.Application.Common.Dtos.Timesheet;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface ITimesheetService
    {
        OperationResult Query();

        OperationResult MetricsQuery();

        Task<OperationResult> Insert(TimesheetPostDto viewModel);

        Task<OperationResult> Update(int id, TimesheetPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}
