using AutoMapper;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Timesheet;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    internal sealed class TimesheetService : EntityService<
        Timesheet,
        TimesheetViewModel,
        TimesheetPostViewModel,
        TimesheetPutViewModel,
        TimesheetValidator>, ITimesheetService
    {
        public TimesheetService(ITimesheetRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}