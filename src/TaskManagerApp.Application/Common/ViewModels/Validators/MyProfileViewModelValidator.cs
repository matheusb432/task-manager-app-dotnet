using FluentValidation;

namespace TaskManagerApp.Application.Common.ViewModels.Validators
{
    internal class MyProfileViewModelValidator : AbstractValidator<MyProfileViewModel>
    {
        public MyProfileViewModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.UserName).MaximumLength(100);
        }
    }
}
