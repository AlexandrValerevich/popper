using FluentValidation;

namespace GifFiles.Application.Queries.GetGifFileById;

public class GetGifByIdQueryValidator : AbstractValidator<GetGifFileByIdQuery>
{
    public GetGifByIdQueryValidator()
    {
        RuleFor(x => x.GifId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}