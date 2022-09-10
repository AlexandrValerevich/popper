using FluentValidation;

namespace Poppers.Application.Gif.Queries.GetGifById;

public class GetGifByIdQueryValidator : AbstractValidator<GetGifByIdQuery>
{
    public GetGifByIdQueryValidator()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}