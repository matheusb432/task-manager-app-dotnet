using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Timesheet;

namespace TaskManagerApp.API.Controllers
{
    [Authorize]
    public sealed class TimesheetsController : Controller
    {
        private readonly ITimesheetService _service;

        public TimesheetsController(ITimesheetService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<TimesheetViewModel>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(TimesheetPostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TimesheetPutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}