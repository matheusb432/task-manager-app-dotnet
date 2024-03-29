﻿using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Common.Dtos.Timesheet;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    public sealed class TimesheetsController : Controller
    {
        private readonly ITimesheetService _service;

        public TimesheetsController(ITimesheetService service) => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<TimesheetDto>> Query() => CustomResponse(_service.Query());

        [HttpGet("metrics/odata")]
        [ODataQuery]
        public ActionResult<IQueryable<TimesheetMetricsViewModel>> MetricsQuery() =>
            CustomResponse(_service.MetricsQuery());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(TimesheetPostDto viewModel) =>
            CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TimesheetPutDto viewModel) =>
            CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => CustomResponse(await _service.Delete(id));
    }
}
