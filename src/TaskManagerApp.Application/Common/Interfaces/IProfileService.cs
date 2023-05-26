using TaskManagerApp.Application.Common.Dtos.Profile;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface IProfileService
    {
        OperationResult Query();

        OperationResult TypesQuery();

        Task<OperationResult> Insert(ProfilePostDto viewModel);

        Task<OperationResult> Update(int id, ProfilePutDto viewModel);

        Task<OperationResult> Delete(int id);
    }
}
