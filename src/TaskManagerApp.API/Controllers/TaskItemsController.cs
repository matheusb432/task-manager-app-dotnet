using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Dtos.TaskItem;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    [Authorize]
    public sealed class TaskItemsController : Controller
    {
        private readonly ITaskItemService _service;

        public TaskItemsController(ITaskItemService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<TaskItemDto>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(TaskItemPostDto viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TaskItemPutDto viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}