using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Login;

public record LoginQuery(string Email, string Password)
    : IRequest<AuthenticationResult>;
