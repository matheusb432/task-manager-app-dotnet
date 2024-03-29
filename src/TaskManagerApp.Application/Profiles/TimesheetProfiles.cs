﻿using TaskManagerApp.Application.Common.Dtos.Timesheet;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class TimesheetProfiles : AutoMapper.Profile
    {
        public TimesheetProfiles()
        {
            CreateMap<TimesheetDto, Timesheet>()
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCreatedId));
            CreateMap<TimesheetPostDto, Timesheet>();
            CreateMap<TimesheetPutDto, Timesheet>();
            CreateMap<TimesheetNote, TimesheetNoteDto>().ReverseMap();
            CreateMap<TimesheetNotePostDto, TimesheetNote>();
            CreateMap<TimesheetNotePutDto, TimesheetNote>();

#pragma warning disable CS8629 // Nullable value type may be null.
            CreateMap<Timesheet, TimesheetMetricsViewModel>()
                .ForMember(dest => dest.TotalTasks, opt => opt.MapFrom(src => src.Tasks.Count))
                .ForMember(
                    dest => dest.WorkedHours,
                    opt => opt.MapFrom(src => src.Tasks.Sum(x => x.Time))
                )
                .ForMember(
                    dest => dest.AverageRating,
                    opt =>
                        opt.MapFrom(
                            src =>
                                src.Tasks.Count > 0
                                    ? (
                                        src.Tasks
                                            .Where(x => x.Rating != null)
                                            .Sum(x => (double)x.Rating) / src.Tasks.Count
                                    )
                                    : 0
                        )
                );
#pragma warning restore CS8629 // Nullable value type may be null.
        }
    }
}
