using FluentValidation;
using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class ProfileTypeValidator : AbstractValidator<ProfileType>
    {
        public ProfileTypeValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.Type).Equal(ProfileTypes.Custom);
            RuleFor(x => x.DateRangeStart).NotEmpty();
            RuleFor(x => x.DateRangeEnd).NotEmpty().GreaterThan(x => x.DateRangeStart);
        }
    }
}
