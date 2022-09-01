using MediatR;

namespace Poppers.Application.Authentication.Command.Logout;

public record LogoutCommand(string RefreshToken)
    : IRequest;