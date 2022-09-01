namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<bool> IsExistedUser(string userName, CancellationToken cancellationToken);
}