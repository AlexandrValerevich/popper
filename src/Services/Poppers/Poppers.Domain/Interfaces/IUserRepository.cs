using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.User;

namespace Poppers.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> ReadById(UserId id, CancellationToken token);
    Task<IEnumerable<User>> ReadAll(CancellationToken token);
    Task Update(User user, CancellationToken token);
    Task Delete(UserId id, CancellationToken token);
    Task Add(User user, CancellationToken token);
}