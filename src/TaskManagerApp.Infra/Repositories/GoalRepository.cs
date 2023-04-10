using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class GoalRepository : Repository<Goal>, IGoalRepository
    {
        public GoalRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}