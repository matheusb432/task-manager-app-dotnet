using AutoMapper;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Application.ViewModels.Goal;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class GoalService : EntityService<
        Goal,
        GoalViewModel,
        GoalPostViewModel,
        GoalPutViewModel,
        GoalValidator>, IGoalService
    {
        public GoalService(IGoalRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}