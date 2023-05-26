using TaskManagerApp.Application.Common.Dtos.Goal;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface IGoalService
    {
        OperationResult Query();

        Task<OperationResult> Insert(GoalPostDto viewModel);

        Task<OperationResult> Update(int id, GoalPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}
