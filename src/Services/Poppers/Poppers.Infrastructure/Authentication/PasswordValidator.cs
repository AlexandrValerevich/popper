using Poppers.Application.Common.Interfaces.Authentication;
using PasswordCrypt = BCrypt.Net.BCrypt;

namespace Poppers.Infrastructure.Authentication;

public class PasswordValidator : IPasswordValidator
{
    public bool IsValid(string passwordHash, string password)
    {
        return PasswordCrypt.Verify(password, passwordHash);
    }
}