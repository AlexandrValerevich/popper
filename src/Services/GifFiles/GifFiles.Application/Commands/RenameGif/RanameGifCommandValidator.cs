using FluentValidation;

namespace GifFiles.Application.Commands.RenameGif;

public class RenameGifCommandValidator : AbstractValidator<RenameGifCommand>
{
    public RenameGifCommandValidator()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}