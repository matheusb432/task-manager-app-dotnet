using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.Profile;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IProfileService
    {
        OperationResult Query();

        Task<OperationResult> FindTypes();

        Task<OperationResult> Insert(ProfilePostViewModel viewModel);

        Task<OperationResult> Update(int id, ProfilePutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}