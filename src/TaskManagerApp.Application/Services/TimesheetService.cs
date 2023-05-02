using AutoMapper;
using TaskManagerApp.Application.Dtos.Timesheet;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class TimesheetService : EntityService<
        Timesheet,
        TimesheetDto,
        TimesheetPostDto,
        TimesheetPutDto,
        TimesheetValidator>, ITimesheetService
    {
        public TimesheetService(ITimesheetRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}