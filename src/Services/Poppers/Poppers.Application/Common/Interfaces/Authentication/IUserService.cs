namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IUserService
{
    Task<bool> IsExistedUser(string userName, CancellationToken cancellationToken);
}