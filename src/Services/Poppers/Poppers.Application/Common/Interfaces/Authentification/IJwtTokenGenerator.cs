namespace Poppers.Application.Common.Interfaces.Authentification;

public interface IJwtTokenGenerator
{
    string Generate(Guid userId, string firstName, string secondName);
}