using FluentValidation;

namespace Poppers.Application.Authentication.Queries.Login;

public class LoginQueryValidator :  AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().Length(4, 20);
        RuleFor(x => x.DeviceId).NotEmpty();
        RuleFor(x => x.IpAddress).NotEmpty();
    }
}