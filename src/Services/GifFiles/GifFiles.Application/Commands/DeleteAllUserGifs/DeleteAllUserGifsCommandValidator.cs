using FluentValidation;
using MediatR;

namespace GifFiles.Application.Commands.DeleteAllUserGifs;

public class DeleteAllUserGifsCommandValidator : AbstractValidator<DeleteAllUserGifsCommand>
{
    public DeleteAllUserGifsCommandValidator()
    {
        RuleFor(x => x.UsesId).NotEmpty();
    }
}