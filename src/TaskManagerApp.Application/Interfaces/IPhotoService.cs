using Microsoft.AspNetCore.Http;
using TaskManagerApp.Application.Extensions;

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