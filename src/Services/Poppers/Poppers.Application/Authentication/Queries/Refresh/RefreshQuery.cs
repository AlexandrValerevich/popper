using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Refresh;

public record RefreshCommand(
    Guid RefreshToken,
    string IpAddress, 
    string DeviceId)
    : IRequest<AuthenticationResult>;