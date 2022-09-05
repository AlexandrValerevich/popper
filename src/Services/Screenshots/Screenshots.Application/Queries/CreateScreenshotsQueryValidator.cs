using FluentValidation;

namespace Screenshots.Application.Queries;

public class CreateScreenshotsQueryValidator : AbstractValidator<CreateScreenshotsQuery>
{
    public CreateScreenshotsQueryValidator()
    {
        RuleFor(x => x.Uri).NotEmpty();
        RuleFor(x => x.Selector).NotEmpty();
        RuleFor(x => x.Duration).InclusiveBetween(3, 30);
    }
}