using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Refresh;

public record RefreshCommand(string RefreshToken)
    : IRequest<AuthenticationResult>;