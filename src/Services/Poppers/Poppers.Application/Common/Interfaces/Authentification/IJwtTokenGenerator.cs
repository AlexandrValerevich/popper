namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string Generate(Guid userId, string firstName, string secondName);
}