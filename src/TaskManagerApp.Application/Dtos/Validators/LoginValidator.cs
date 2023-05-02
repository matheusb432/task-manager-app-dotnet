using FluentValidation;
using TaskManagerApp.Application.Dtos.Auth;

namespace TaskManagerApp.Application.Dtos.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).MaximumLength(100);
            RuleFor(x => x.UserName).MaximumLength(100);
            RuleFor(x => x.Password).MaximumLength(50);
            RuleFor(x => x.UserName).NotEmpty().When(x => string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Email).NotEmpty().When(x => string.IsNullOrEmpty(x.UserName));
        }
    }
}