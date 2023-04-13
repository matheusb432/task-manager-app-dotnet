using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Application.ViewModels.Goal;
using TaskManagerApp.Application.ViewModels.Timesheet;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class GoalProfiles : AutoMapper.Profile
    {
        public GoalProfiles()
        {
            CreateMap<Goal, GoalViewModel>().ReverseMap();
            CreateMap<GoalPostViewModel, Goal>();
            CreateMap<GoalPutViewModel, Goal>();
            CreateMap<GoalStep, GoalStepViewModel>().ReverseMap();
            CreateMap<GoalStepPostViewModel, GoalStep>();
            CreateMap<GoalStepPutViewModel, GoalStep>();
            CreateMap<GoalTaskItem, GoalTaskItemViewModel>().ReverseMap();
            CreateMap<GoalTaskItemPostViewModel, GoalTaskItem>();
            CreateMap<GoalTaskItemPutViewModel, GoalTaskItem>();
        }
    }
}
