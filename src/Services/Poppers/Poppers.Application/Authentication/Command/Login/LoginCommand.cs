using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Login;

public record LoginCommand(string UserName, string Password)
    : IRequest<AuthenticationResult>;
