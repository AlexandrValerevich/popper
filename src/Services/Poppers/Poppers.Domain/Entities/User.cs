using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Entities;

public class User
{
    public UserId Id;
    private readonly string _firstName;
    private readonly string _secondName;
    private readonly Email _email;
    private readonly string _passwordHash;

    internal User(UserId userId,
        string firstName,
        string secondName,
        string passwordHash,
        Email email)
    {
        Id = userId;
        _firstName = firstName;
        _secondName = secondName;
        _passwordHash = passwordHash;
        _email = email;
    }

    private User() { }

    public string FirstName => _firstName;

    public string SecondName => _secondName;

    public string PasswordHash => _passwordHash;

    public string Email => _email.Value;
}