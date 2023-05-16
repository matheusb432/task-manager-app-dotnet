using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class GoalValidator : AbstractValidator<Goal>
    {
        public GoalValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Image).MaximumLength(200);
        }
    }
}
