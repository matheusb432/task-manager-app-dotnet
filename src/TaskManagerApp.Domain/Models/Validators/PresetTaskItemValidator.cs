﻿using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public class PresetTaskItemValidator : AbstractValidator<PresetTaskItem>
    {
        public PresetTaskItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}