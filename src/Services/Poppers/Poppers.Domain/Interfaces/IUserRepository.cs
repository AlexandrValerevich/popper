using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> ReadById(UserId id);
    Task<IEnumerable<User>> ReadAll();
    Task Update(UserId id, User newUser);
    Task Delete(UserId id);
}