using FluentValidation;
using GifFiles.Application.Queries;

namespace Poppers.Application.Gif.Validators;

public class GetGifByIdQueryValidator : AbstractValidator<GetGifFileByIdQuery>
{
    public GetGifByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}