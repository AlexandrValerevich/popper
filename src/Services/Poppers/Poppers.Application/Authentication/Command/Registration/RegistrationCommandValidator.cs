using FluentValidation;

namespace Poppers.Application.Authentication.Command.Registration;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    public RegistrationCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.SecondName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().Length(4, 20);
    }
}