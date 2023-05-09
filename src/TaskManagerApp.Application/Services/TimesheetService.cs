using AutoMapper;
using System.Net;
using TaskManagerApp.Application.Dtos.Timesheet;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Application.ViewModels;
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
        TimesheetValidator,
        ITimesheetRepository>, ITimesheetService
    {
        public TimesheetService(ITimesheetRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }

        public OperationResult MetricsQuery() => Success(Mapper.ProjectTo<TimesheetMetricsViewModel>(_repo.Query()));

        public override async Task<OperationResult> Update(int id, TimesheetPutDto dto)
        {
            var entity = Mapper.Map<Timesheet>(dto);

            if (!EntityIsValid(new TimesheetValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            if (!await _repo.ExistsAsync(id))
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteMissingRelationsFromRequestAsync(entity, false);
            await _repo.UpdateAsync(entity);

            return Success();
        }
    }
}