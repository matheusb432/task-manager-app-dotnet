using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.TimeTarget).NotEmpty();
            RuleFor(x => x.TasksTarget).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProfileTypeId).NotEmpty();
        }
    }
}