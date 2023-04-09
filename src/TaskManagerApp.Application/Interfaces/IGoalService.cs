using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.Goal;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IGoalService
    {
        OperationResult Query();

        Task<OperationResult> Insert(GoalPostViewModel viewModel);

        Task<OperationResult> Update(int id, GoalPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}