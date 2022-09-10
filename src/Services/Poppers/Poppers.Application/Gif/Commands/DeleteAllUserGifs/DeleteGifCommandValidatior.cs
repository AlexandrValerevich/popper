using FluentValidation;

namespace Poppers.Application.Gif.Commands.DeleteAllUserGifs;

public class DeleteAllUserGifsCommandValidation : AbstractValidator<DeleteAllUserGifsCommand>
{
    public DeleteAllUserGifsCommandValidation()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}