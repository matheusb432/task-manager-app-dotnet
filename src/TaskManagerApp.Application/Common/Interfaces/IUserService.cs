using TaskManagerApp.Application.Common.Dtos.User;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface IUserService
    {
        OperationResult Query();

        OperationResult RolesQuery();

        Task<OperationResult> Insert(UserPostDto viewModel);

        Task<OperationResult> Update(int id, UserPutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}
