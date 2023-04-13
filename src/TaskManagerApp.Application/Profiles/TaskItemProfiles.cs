using TaskManagerApp.Application.ViewModels.TaskItem;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class TaskItemProfiles : AutoMapper.Profile
    {
        public TaskItemProfiles()
        {
            CreateMap<TaskItem, TaskItemViewModel>().ReverseMap()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int) src.Importance)));
            CreateMap<TaskItemPostViewModel, TaskItem>()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance)));
            CreateMap<TaskItemPutViewModel, TaskItem>()
                .ForMember(dest => dest.Importance, opt => opt.MapFrom(src => Math.Max(1, (int)src.Importance)));
            CreateMap<PresetTaskItem, PresetTaskItemViewModel>().ReverseMap();
            CreateMap<PresetTaskItemPostViewModel, PresetTaskItem>();
            CreateMap<PresetTaskItemPutViewModel, PresetTaskItem>();
            CreateMap<TaskItemNote, TaskItemNoteViewModel>().ReverseMap();
            CreateMap<TaskItemNotePostViewModel, TaskItemNote>();
            CreateMap<TaskItemNotePutViewModel, TaskItemNote>();
        }
    }
}