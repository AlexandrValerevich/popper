using FluentValidation;

namespace Poppers.Application.Gif.Commands.CreateGif;

public class CreateGifCommandValidator : AbstractValidator<CreateGifCommand>
{
    public CreateGifCommandValidator()
    {
        RuleFor(x => x.Uri).NotEmpty();
        RuleFor(x => x.ElementSelector).NotEmpty();
        RuleFor(x => x.Duration).InclusiveBetween(3, 30);
        RuleFor(x => x.UserId).NotEmpty();
    }
}