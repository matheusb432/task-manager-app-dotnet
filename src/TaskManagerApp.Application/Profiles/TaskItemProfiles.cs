using TaskManagerApp.Application.Dtos.TaskItem;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class TaskItemProfiles : AutoMapper.Profile
    {
        public TaskItemProfiles()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int) src.Importance)));
            CreateMap<TaskItemPostDto, TaskItem>()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance)));
            CreateMap<TaskItemPutDto, TaskItem>()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance)));
            CreateMap<PresetTaskItemDto, PresetTaskItem>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCreatedId));
            CreateMap<PresetTaskItemPostDto, PresetTaskItem>();
            CreateMap<PresetTaskItemPutDto, PresetTaskItem>();
            CreateMap<TaskItemNote, TaskItemNoteDto>().ReverseMap();
            CreateMap<TaskItemNotePostDto, TaskItemNote>();
            CreateMap<TaskItemNotePutDto, TaskItemNote>();
        }
    }
}