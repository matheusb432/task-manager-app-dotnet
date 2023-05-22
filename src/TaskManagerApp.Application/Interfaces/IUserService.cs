using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
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
