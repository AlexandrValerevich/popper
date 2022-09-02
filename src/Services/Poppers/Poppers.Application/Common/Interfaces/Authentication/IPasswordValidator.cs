namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IPasswordValidator
{
    bool IsValid(string passwordHash, string password);
}