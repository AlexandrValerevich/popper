using FluentValidation;

namespace Poppers.Application.Gif.Commands.RenameGif;

public class RenameGifCommandValidation : AbstractValidator<RenameGifCommand>
{
    public RenameGifCommandValidation()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}