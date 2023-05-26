using AutoMapper;
using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class TaskItemService
        : EntityService<
            TaskItem,
            TaskItemDto,
            TaskItemPostDto,
            TaskItemPutDto,
            TaskItemValidator,
            ITaskItemRepository
        >,
            ITaskItemService
    {
        public TaskItemService(ITaskItemRepository repo, IMapper mapper) : base(mapper, repo) { }
    }
}
