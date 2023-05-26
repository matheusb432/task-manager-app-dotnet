using AutoMapper;
using TaskManagerApp.Application.Common.Dtos.Goal;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class GoalService
        : EntityService<Goal, GoalDto, GoalPostDto, GoalPutDto, GoalValidator, IGoalRepository>,
            IGoalService
    {
        public GoalService(IGoalRepository repo, IMapper mapper) : base(mapper, repo) { }
    }
}
