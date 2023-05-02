using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Application.Dtos.Timesheet;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class TimesheetProfiles : AutoMapper.Profile
    {
        public TimesheetProfiles()
        {
            CreateMap<Timesheet, TimesheetDto>().ReverseMap();
            CreateMap<TimesheetPostDto, Timesheet>();
            CreateMap<TimesheetPutDto, Timesheet>();
            CreateMap<TimesheetNote, TimesheetNoteDto>().ReverseMap();
            CreateMap<TimesheetNotePostDto, TimesheetNote>();
            CreateMap<TimesheetNotePutDto, TimesheetNote>();
        }
    }
}
