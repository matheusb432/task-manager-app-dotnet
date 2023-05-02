using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Application.Dtos.Goal;
using TaskManagerApp.Application.Dtos.Timesheet;
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
