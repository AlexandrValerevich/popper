using FluentValidation;
using Poppers.Application.Gif.Commands;

namespace Poppers.Application.Gif.Validators;

public class DeleteGifCommandValidatior : AbstractValidator<DeleteGifCommand>
{
    public DeleteGifCommandValidatior()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}