using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.API.Controllers
{
    [ApiController]
    public sealed class TaskItemsController : Controller
    {
        private readonly ITaskItemService _service;

        public TaskItemsController(ITaskItemService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<TaskItemViewModel>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(TaskItemPostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TaskItemPutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}