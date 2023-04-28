using TaskManagerApp.Application.Dtos;
using TaskManagerApp.Application.Extensions;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IAuthService
    {
        // TODO - implement auth methods
        Task<OperationResult> Login(Login login);
        Task<OperationResult> Signup(Signup signup);
    }
}