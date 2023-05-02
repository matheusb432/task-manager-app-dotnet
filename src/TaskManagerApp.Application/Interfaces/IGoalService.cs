using TaskManagerApp.Application.Dtos.Goal;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IGoalService
    {
        OperationResult Query();

        Task<OperationResult> Insert(GoalPostDto viewModel);

        Task<OperationResult> Update(int id, GoalPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}