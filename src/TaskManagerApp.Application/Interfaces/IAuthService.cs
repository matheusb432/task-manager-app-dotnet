using TaskManagerApp.Application.Dtos.Auth;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> Login(Login login);
        Task<OperationResult> Signup(Signup signup);
    }
}