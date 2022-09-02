namespace Shared.Poppers.Contracts.V1.Authentication.Requests;

public record RegistrationRequest(
    string FirstName,
    string SecondName,
    string Email,
    string Password
);