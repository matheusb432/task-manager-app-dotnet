using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.User;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IUserService
    {
        OperationResult Query();

        Task<OperationResult> Insert(UserPostViewModel viewModel);

        Task<OperationResult> Update(int id, UserPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}