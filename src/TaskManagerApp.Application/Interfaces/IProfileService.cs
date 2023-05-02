using TaskManagerApp.Application.Dtos.Profile;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
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