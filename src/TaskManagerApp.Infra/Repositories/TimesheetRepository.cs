﻿using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal sealed class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        public TimesheetRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}