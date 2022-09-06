using FluentValidation;

namespace GifFiles.Application.Commands.DeleteGifFile;

public class DeleteGifByIdCommandValidator : AbstractValidator<DeleteGifByIdCommand>
{
    public DeleteGifByIdCommandValidator()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}