using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class PresetTaskItemValidator : AbstractValidator<PresetTaskItem>
    {
        public PresetTaskItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        }
    }
}
