using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Infrastructure.Authentification;

public class PasswordChecker : IPasswordChecker
{
    public bool IsCorrectPassword(string hashedPassword, string password)
    {
        return true;
    }
}