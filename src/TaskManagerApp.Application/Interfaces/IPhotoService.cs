using TaskManagerApp.Application.Extensions;
using Microsoft.AspNetCore.Http;

namespace TaskManagerApp.Application.Interfaces
{
    public interface IPhotoService
    {
        OperationResult Query();

        Task<OperationResult> Insert(IFormFile image);

        Task<OperationResult> Update(int id, IFormFile image);

        Task<OperationResult> Delete(int id);
    }
}
