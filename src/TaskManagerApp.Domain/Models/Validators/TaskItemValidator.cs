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
#pragma warning disable CS8629
            RuleFor(x => (int)x.Rating).InclusiveBetween(1, 5).When(x => x.Rating.HasValue);
            RuleFor(x => (int)x.Time).InclusiveBetween(1, 2400).When(x => x.Time.HasValue);
#pragma warning restore CS8629
            RuleFor(x => (int)x.Importance).NotEmpty().InclusiveBetween(1, 3);
            RuleFor(x => x.Title).NotEmpty().When(x => !x.PresetTaskItemId.HasValue);
        }
    }
}
