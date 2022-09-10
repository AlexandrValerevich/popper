using ValueOf;

namespace Poppers.Domain.ValueObjects.User;

public class UserId : ValueOf<Guid, UserId>
{
    public static implicit operator Guid(UserId id) => id.Value;
    public static implicit operator UserId(Guid value) => From(value);
}
