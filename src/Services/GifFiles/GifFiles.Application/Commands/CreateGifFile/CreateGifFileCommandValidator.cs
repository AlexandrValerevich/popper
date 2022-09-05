using FluentValidation;

namespace GifFiles.Application.Commands.CreateGifFile;

public class CreateGifFileCommandValidator : AbstractValidator<CreateGifFileCommand>
{
    public CreateGifFileCommandValidator()
    {
        RuleFor(x => x.Delay).NotEmpty().InclusiveBetween(10, 100);
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Images).NotEmpty();
    }
}