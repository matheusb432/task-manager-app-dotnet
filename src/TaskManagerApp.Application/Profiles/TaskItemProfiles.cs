using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class TaskItemProfiles : AutoMapper.Profile
    {
        public TaskItemProfiles()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ReverseMap()
                .ForMember(
                    dest => dest.Importance,
                    opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance))
                );
            CreateMap<TaskItemPostDto, TaskItem>()
                .ForMember(
                    dest => dest.Importance,
                    opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance))
                )
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.Time))
                );
            CreateMap<TaskItemPutDto, TaskItem>()
                .ForMember(
                    dest => dest.Importance,
                    opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance))
                )
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.Time))
                );
            CreateMap<PresetTaskItemDto, PresetTaskItem>()
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCreatedId));
            CreateMap<PresetTaskItemPostDto, PresetTaskItem>();
            CreateMap<PresetTaskItemPutDto, PresetTaskItem>();
        }
    }
}
