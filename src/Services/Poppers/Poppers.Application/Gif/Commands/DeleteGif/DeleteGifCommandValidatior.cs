using FluentValidation;

namespace Poppers.Application.Gif.Commands.DeleteGif;

public class DeleteGifCommandValidation : AbstractValidator<DeleteGifCommand>
{
    public DeleteGifCommandValidation()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}