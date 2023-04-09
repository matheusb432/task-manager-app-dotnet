using FluentValidation;

namespace TaskManagerApp.Domain.Models.Validators
{
    public sealed class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(e => e.PhotoId).NotEmpty().When(e => e.Photo is null);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Status).MaximumLength(100);
        }
    }
}
