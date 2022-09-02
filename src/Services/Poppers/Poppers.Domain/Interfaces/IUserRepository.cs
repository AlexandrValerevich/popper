using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> ReadById(UserId id);
    Task<IEnumerable<User>> ReadAll();
    Task Update(User user);
    Task Delete(UserId id);
    Task Add(User user);
}