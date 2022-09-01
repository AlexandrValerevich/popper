using MediatR;

namespace Poppers.Application.Authentification.Command;

public record LogoutCommand(string RefreshToken) 
    : IRequest;