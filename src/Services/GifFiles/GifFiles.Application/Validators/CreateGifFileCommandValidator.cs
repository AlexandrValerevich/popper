using FluentValidation;
using GifFiles.Application.Commands;

namespace Poppers.Application.Gif.Validators;

public class CreateGifFileCommandValidator : AbstractValidator<CreateGifFileCommand>
{
    public CreateGifFileCommandValidator()
    {
        RuleFor(x => x.Delay).NotEmpty().InclusiveBetween(10, 100);
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Images).NotEmpty();
    }
}