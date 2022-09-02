using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password)
    : IRequest<AuthenticationResult>;
