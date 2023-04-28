using AutoMapper;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Application.ViewModels.TaskItem;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class TaskItemService : EntityService<
        TaskItem,
        TaskItemViewModel,
        TaskItemPostViewModel,
        TaskItemPutViewModel,
        TaskItemValidator>, ITaskItemService
    {
        public TaskItemService(ITaskItemRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}