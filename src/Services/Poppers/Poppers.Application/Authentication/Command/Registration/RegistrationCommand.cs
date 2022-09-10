using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Authentication.Command.Registration;

public record RegistrationCommand(
    string FirstName,
    string SecondName,
    string Email,
    string Password,
    string IpAddress,
    string DeviceId
) : ICommand<AuthenticationResult>;