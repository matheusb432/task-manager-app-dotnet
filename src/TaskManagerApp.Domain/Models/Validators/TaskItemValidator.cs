using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Title).MaximumLength(100);
            RuleFor(x => x.Time).NotNull().When(x => !x.Rating.HasValue);
            RuleFor(x => x.Rating).NotNull().When(x => !x.Time.HasValue);
            RuleFor(x => x.Title).NotEmpty().When(x => !x.PresetTaskItemId.HasValue);
        }
    }
}
