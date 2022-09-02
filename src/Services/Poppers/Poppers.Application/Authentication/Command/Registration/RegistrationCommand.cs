using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Registration;

public record RegistrationCommand(
    string FirstName,
    string SecondName,
    string Email,
    string Password,
    string IpAddress
) : IRequest<AuthenticationResult>;