using FluentValidation;
using TaskManagerApp.Application.Common.Dtos.Auth;

namespace TaskManagerApp.Application.Common.Dtos.Validators
{
    public sealed class SignupValidator : AbstractValidator<Signup>
    {
        public SignupValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
        }
    }
}
