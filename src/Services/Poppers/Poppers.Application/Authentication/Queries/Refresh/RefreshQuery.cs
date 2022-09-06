using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Queries.Refresh;

public record RefreshQuery(
    Guid RefreshToken,
    string IpAddress,
    string DeviceId)
    : IRequest<AuthenticationResult>;