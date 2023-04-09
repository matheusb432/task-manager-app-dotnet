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
    public class GoalProfiles : AutoMapper.Profile
    {
        public GoalProfiles()
        {
            CreateMap<Goal, GoalViewModel>();
            CreateMap<GoalPostViewModel, Goal>();
            CreateMap<GoalPutViewModel, Goal>();
            CreateMap<GoalStep, GoalStepViewModel>();
            CreateMap<GoalStepPostViewModel, GoalStep>();
            CreateMap<GoalStepPutViewModel, GoalStep>();
            CreateMap<GoalTaskItem, GoalTaskItemViewModel>();
            CreateMap<GoalTaskItemPostViewModel, GoalTaskItem>();
            CreateMap<GoalTaskItemPutViewModel, GoalTaskItem>();
        }
    }
}
