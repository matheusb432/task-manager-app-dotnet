using TaskManagerApp.Application.Dtos.TaskItem;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
{
    public interface ITaskItemService
    {
        OperationResult Query();

        Task<OperationResult> Insert(TaskItemPostDto viewModel);

        Task<OperationResult> Update(int id, TaskItemPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}