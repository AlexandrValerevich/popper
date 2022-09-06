using FluentValidation;

namespace Poppers.Application.Authentication.Queries.Refresh;

public class RefreshQueryValidator : AbstractValidator<RefreshQuery>
{
    public RefreshQueryValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
        RuleFor(x => x.DeviceId).NotEmpty();
        RuleFor(x => x.IpAddress).NotEmpty();
    }
}