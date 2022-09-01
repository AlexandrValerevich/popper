namespace Poppers.Application.Common.Interfaces.Authentification;

public interface IPasswordChecker
{
    bool IsCorrectPassword(string hashedPassword, string password);
}