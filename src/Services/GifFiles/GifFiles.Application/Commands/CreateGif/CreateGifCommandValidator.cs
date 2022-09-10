using FluentValidation;

namespace GifFiles.Application.Commands.CreateGif;

public class CreateGifCommandValidator : AbstractValidator<CreateGifCommand>
{
    public CreateGifCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Delay).NotEmpty().InclusiveBetween(10, 100);
        RuleFor(x => x.Images).NotEmpty();
    }
}