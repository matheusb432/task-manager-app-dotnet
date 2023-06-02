using AutoMapper;
using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class PresetTaskItemService
        : EntityService<
            PresetTaskItem,
            PresetTaskItemDto,
            PresetTaskItemPostDto,
            PresetTaskItemPutDto,
            PresetTaskItemValidator,
            IPresetTaskItemRepository
        >,
            IPresetTaskItemService
    {
        public PresetTaskItemService(IPresetTaskItemRepository repo, IMapper mapper)
            : base(mapper, repo) { }
    }
}
