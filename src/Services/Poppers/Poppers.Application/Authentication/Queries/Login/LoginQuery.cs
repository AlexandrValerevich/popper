using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, 
    string Password, 
    string IpAddress,
    string DeviceId)
    : IRequest<AuthenticationResult>;
