using TaskManagerApp.Application.Common.Dtos.Goal;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class GoalProfiles : AutoMapper.Profile
    {
        public GoalProfiles()
        {
            CreateMap<Goal, GoalDto>().ReverseMap();
            CreateMap<GoalPostDto, Goal>();
            CreateMap<GoalPutDto, Goal>();
            CreateMap<GoalStep, GoalStepDto>().ReverseMap();
            CreateMap<GoalStepPostDto, GoalStep>();
            CreateMap<GoalStepPutDto, GoalStep>();
            CreateMap<GoalTaskItem, GoalTaskItemDto>().ReverseMap();
            CreateMap<GoalTaskItemPostDto, GoalTaskItem>();
            CreateMap<GoalTaskItemPutDto, GoalTaskItem>();
        }
    }
}
