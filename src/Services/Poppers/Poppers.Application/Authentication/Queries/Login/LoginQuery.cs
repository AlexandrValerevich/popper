using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Cqrs;

namespace Poppers.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, 
    string Password, 
    string IpAddress,
    string DeviceId)
    : IQuery<AuthenticationResult>;
