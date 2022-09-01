using MediatR;

namespace Poppers.Application.Authentication.Command.Logout;

public record LogoutQuery(string RefreshToken)
    : IRequest;