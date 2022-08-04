using FluentValidation;
using GifFiles.Application.Commands;

namespace Poppers.Application.Gif.Validators;

public class DeleteGifFileCommandValidator : AbstractValidator<DeleteGifFileCommand>
{
    public DeleteGifFileCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}