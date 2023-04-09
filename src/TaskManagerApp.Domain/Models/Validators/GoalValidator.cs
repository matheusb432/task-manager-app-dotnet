﻿using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public class GoalValidator : AbstractValidator<Goal>
    {
        public GoalValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Image).MaximumLength(200);
        }
    }
}