using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface IPresetTaskItemService
    {
        OperationResult Query();

        Task<OperationResult> Insert(PresetTaskItemPostDto dto);

        Task<OperationResult> Update(int id, PresetTaskItemPutDto dto);

        Task<OperationResult> Delete(int id);
    }
}
