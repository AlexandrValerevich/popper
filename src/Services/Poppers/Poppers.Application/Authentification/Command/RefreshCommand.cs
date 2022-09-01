using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public record RefreshCommand(string RefreshToken) 
    : IRequest<AuthentificationResult>;