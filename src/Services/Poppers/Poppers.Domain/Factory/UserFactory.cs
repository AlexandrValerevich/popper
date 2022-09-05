using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.User;

namespace Poppers.Domain.Factory;

public class UserFactory : IUserFactory
{
    public User Create(UserId id, string firstName, string secondName, Email email, string passwordHash)
    {
        return new User(id, firstName, secondName, email, passwordHash);
    }
}