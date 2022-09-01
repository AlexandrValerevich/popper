using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public record LoginCommand(string UserName, string Password) 
    : IRequest<AuthentificationResult>;
