﻿using FluentValidation;
using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Domain.Models.Validators
{
    public class ProfileTypeValidator : AbstractValidator<ProfileType>
    {
        public ProfileTypeValidator()
        {
            RuleFor(x => x.Name).MaximumLength(200).NotEmpty();
            RuleFor(x => x.Type).Equal(ProfileTypes.Custom);
            RuleFor(x => x.DateRangeStart).NotEmpty();
            // TODO test validation
            RuleFor(x => x.DateRangeEnd).NotEmpty().GreaterThan(x => x.DateRangeStart);
        }
    }
}