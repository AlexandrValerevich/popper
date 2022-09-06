using FluentValidation;

namespace GifFiles.Application.Queries.GetAllUserGifs;

public class GetAllUserGifsQueryValidator : AbstractValidator<GetAllUserGifsQuery>
{
    public GetAllUserGifsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}