using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Registration;

public record RegistrationCommand() : IRequest<AuthenticationResult>;