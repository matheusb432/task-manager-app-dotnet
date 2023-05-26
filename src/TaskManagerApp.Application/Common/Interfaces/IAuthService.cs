using TaskManagerApp.Application.Common.Dtos.Auth;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> Login(Login login);

        Task<OperationResult> Signup(Signup signup);
    }
}
