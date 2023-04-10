﻿using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class TimesheetValidator : AbstractValidator<Timesheet>
    {
        public TimesheetValidator()
        {
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}