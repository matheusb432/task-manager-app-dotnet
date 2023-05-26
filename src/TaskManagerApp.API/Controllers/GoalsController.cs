using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Common.Dtos.Goal;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    public sealed class GoalsController : Controller
    {
        private readonly IGoalService _service;

        public GoalsController(IGoalService service) => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<GoalDto>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(GoalPostDto viewModel) =>
            CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, GoalPutDto viewModel) =>
            CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => CustomResponse(await _service.Delete(id));
    }
}
