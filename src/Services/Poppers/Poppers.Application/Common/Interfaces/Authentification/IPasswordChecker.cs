namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IPasswordChecker
{
    bool IsCorrectPassword(string hashedPassword, string password);
}