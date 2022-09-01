using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Infrastructure.Authentication;

public class UserService : IUserService
{
    public Task<bool> IsExistedUser(string userName, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}