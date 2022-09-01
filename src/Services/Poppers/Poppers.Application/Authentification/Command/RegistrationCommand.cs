using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public record RegistrationCommand() : IRequest<AuthentificationResult>;