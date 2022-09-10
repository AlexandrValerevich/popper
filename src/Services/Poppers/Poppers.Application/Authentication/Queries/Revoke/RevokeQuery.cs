using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Authentication.Queries.Revoke;

public record RevokeQuery(Guid RefreshToken, string DeviceId)
    : IQuery;