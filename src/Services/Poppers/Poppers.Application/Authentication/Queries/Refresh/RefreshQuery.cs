using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Authentication.Queries.Refresh;

public record RefreshQuery(
    Guid RefreshToken,
    string IpAddress,
    string DeviceId)
    : IQuery<AuthenticationResult>;