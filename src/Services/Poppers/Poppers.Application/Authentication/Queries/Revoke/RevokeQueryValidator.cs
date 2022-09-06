using FluentValidation;

namespace Poppers.Application.Authentication.Queries.Revoke;

public class RevokeQueryValidator : AbstractValidator<RevokeQuery>
{
    public RevokeQueryValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
        RuleFor(x => x.DeviceId).NotEmpty();
    }
}