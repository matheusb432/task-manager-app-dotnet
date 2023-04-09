﻿using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.HoursTarget).NotEmpty();
            RuleFor(x => x.TasksTarget).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProfileTypeId).NotEmpty();
        }
    }
}