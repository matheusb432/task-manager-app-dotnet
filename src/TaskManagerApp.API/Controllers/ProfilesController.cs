using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Common.Dtos.Profile;
using TaskManagerApp.Application.Common.Dtos.TaskItem;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    public sealed class ProfilesController : Controller
    {
        private readonly IProfileService _service;
        private readonly IPresetTaskItemService _presetTaskItemService;

        public ProfilesController(
            IProfileService service,
            IPresetTaskItemService presetTaskItemService
        )
        {
            _service = service;
            _presetTaskItemService = presetTaskItemService;
        }

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<ProfileDto>> Query() => CustomResponse(_service.Query());

        [HttpGet("types/odata")]
        [ResponseCache(Duration = 86400)]
        [ODataQuery]
        [AllowAnonymous]
        public ActionResult<List<ProfileTypeDto>> TypesQuery() =>
            CustomResponse(_service.TypesQuery());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(ProfilePostDto viewModel) =>
            CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProfilePutDto viewModel) =>
            CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => CustomResponse(await _service.Delete(id));

        [HttpGet("tasks/odata")]
        [ODataQuery]
        public ActionResult<IQueryable<PresetTaskItemDto>> TaskQuery() =>
            CustomResponse(_presetTaskItemService.Query());

        [HttpPut("tasks/{id}")]
        public async Task<ActionResult> TaskPut(int id, PresetTaskItemPutDto dto) =>
            CustomResponse(await _presetTaskItemService.Update(id, dto));

        [HttpDelete("tasks/{id}")]
        public async Task<ActionResult> TaskDelete(int id) =>
            CustomResponse(await _presetTaskItemService.Delete(id));

        [HttpPost("tasks")]
        public async Task<ActionResult> TaskPost(PresetTaskItemPostDto dto)
        {
            return CustomResponse(await _presetTaskItemService.Insert(dto));
        }
    }
}
