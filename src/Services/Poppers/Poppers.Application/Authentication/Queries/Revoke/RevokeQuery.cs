using MediatR;

namespace Poppers.Application.Authentication.Queries.Revoke;

public record RevokeQuery(Guid RefreshToken)
    : IRequest;