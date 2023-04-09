using TaskManagerApp.Application.ViewModels.TaskItem;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public class TaskItemProfiles : AutoMapper.Profile
    {
        public TaskItemProfiles()
        {
            CreateMap<TaskItem, TaskItemViewModel>();
            CreateMap<TaskItemPostViewModel, TaskItem>();
            CreateMap<TaskItemPutViewModel, TaskItem>();
            CreateMap<PresetTaskItem, PresetTaskItemViewModel>();
            CreateMap<PresetTaskItemPostViewModel, PresetTaskItem>();
            CreateMap<PresetTaskItemPutViewModel, PresetTaskItem>();
            CreateMap<TaskItemNote, TaskItemNoteViewModel>();
            CreateMap<TaskItemNotePostViewModel, TaskItemNote>();
            CreateMap<TaskItemNotePutViewModel, TaskItemNote>();
        }
    }
}