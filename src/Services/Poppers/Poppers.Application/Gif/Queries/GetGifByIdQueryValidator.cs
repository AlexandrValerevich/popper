using FluentValidation;
using Poppers.Application.Gif.Queries;

namespace Poppers.Application.Gif.Validators;

public class GetGifByIdQueryValidator : AbstractValidator<GetGifByIdQuery>
{
    public GetGifByIdQueryValidator()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}