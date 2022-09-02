namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IPasswordHasher
{
    string HashPassword(string password);
}