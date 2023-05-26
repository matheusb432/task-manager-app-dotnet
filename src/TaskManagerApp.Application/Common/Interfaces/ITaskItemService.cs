using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface ITaskItemService
    {
        OperationResult Query();

        Task<OperationResult> Insert(TaskItemPostDto viewModel);

        Task<OperationResult> Update(int id, TaskItemPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}
