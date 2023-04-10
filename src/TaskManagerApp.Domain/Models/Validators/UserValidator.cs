using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(250);
        }
    }
}