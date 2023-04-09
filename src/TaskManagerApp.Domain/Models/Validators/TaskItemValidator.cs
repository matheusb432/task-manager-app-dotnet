using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Hours).NotEmpty();
            RuleFor(x => x.TimesheetId).NotEmpty();
        }
    }
}