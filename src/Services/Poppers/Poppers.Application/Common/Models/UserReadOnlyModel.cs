namespace Poppers.Application.Common.Models;

public record UserReadOnlyModel(
    Guid Id,
    string FirstName,
    string SecondName,
    string PasswordHash,
    string Email
);