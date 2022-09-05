using FluentValidation;

namespace GifFiles.Application.Commands.DeleteGifFile;

public class DeleteGifFileCommandValidator : AbstractValidator<DeleteGifFileCommand>
{
    public DeleteGifFileCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}