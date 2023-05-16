using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().MaximumLength(100);
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
        }
    }
}
