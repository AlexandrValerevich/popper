using FluentValidation;
using GifFiles.Application.Commands;

namespace Poppers.Application.Gif.Validators;

public class DeleteGifFileCommandValidatior : AbstractValidator<DeleteGifFileCommand>
{
    public DeleteGifFileCommandValidatior()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}