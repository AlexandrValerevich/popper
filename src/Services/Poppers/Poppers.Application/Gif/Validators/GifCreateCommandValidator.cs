using FluentValidation;
using Poppers.Application.Gif.Commands;

namespace Poppers.Application.Gif.Validators;

public class GifCreateCommandValidator : AbstractValidator<GifCreateCommand>
{
    public GifCreateCommandValidator()
    {
        RuleFor(x => x.Uri).NotEmpty();
        RuleFor(x => x.ElementSelector).NotEmpty();
        RuleFor(x => x.Duration).InclusiveBetween(2, 30);
    }
}