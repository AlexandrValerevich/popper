using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Factory;

public interface IUserFactory
{
    User Create(UserId id, string firstName, string secondName, Email email, string passwordHash);
}