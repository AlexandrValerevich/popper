using Poppers.Application.Common.Interfaces.Authentication;
using PasswordCrypt = BCrypt.Net.BCrypt;

namespace Poppers.Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return PasswordCrypt.HashPassword(password);
    }
}