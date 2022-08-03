using FluentValidation;
using Poppers.Application.Gif.Commands;

namespace Poppers.Application.Gif.Validators;

public class CreateGifCommandValidator : AbstractValidator<CreateGifCommand>
{
    public CreateGifCommandValidator()
    {
        RuleFor(x => x.Uri).NotEmpty();
        RuleFor(x => x.ElementSelector).NotEmpty();
        RuleFor(x => x.Duration).InclusiveBetween(3, 30);
    }
}