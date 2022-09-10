using FluentValidation;

namespace Poppers.Application.Gif.Queries.GetGifById;

public class GetAllUserGifsQueryValidator : AbstractValidator<GetAllUserGifsQuery>
{
    public GetAllUserGifsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}