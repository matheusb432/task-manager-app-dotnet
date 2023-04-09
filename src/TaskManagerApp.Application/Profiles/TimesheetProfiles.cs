using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagerApp.Application.ViewModels.Timesheet;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public class TimesheetProfiles : AutoMapper.Profile
    {
        public TimesheetProfiles()
        {
            CreateMap<Timesheet, TimesheetViewModel>();
            CreateMap<TimesheetPostViewModel, Timesheet>();
            CreateMap<TimesheetPutViewModel, Timesheet>();
            CreateMap<TimesheetNote, TimesheetNoteViewModel>();
            CreateMap<TimesheetNotePostViewModel, TimesheetNote>();
            CreateMap<TimesheetNotePutViewModel, TimesheetNote>();
        }
    }
}
