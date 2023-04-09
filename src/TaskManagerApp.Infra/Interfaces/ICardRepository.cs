using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<Card?> GetByPhotoIdAsync(long photoId);
    }
}
