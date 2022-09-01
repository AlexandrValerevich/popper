using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Infrastructure.Persistence;

public class UserRespository : IUserRepository
{
    public Task<bool> IsExistedUser(string userName, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}