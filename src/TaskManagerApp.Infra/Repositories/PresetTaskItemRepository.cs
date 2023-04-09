using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal class PresetTaskItemRepository : Repository<PresetTaskItem>, IPresetTaskItemRepository
    {
        public PresetTaskItemRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}