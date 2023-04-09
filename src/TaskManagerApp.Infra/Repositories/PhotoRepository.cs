using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}