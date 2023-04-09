using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.Interfaces
{
    public interface ITaskItemService
    {
        OperationResult Query();

        Task<OperationResult> Insert(TaskItemPostViewModel viewModel);

        Task<OperationResult> Update(int id, TaskItemPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}