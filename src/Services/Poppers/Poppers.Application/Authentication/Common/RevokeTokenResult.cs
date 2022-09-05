namespace Poppers.Application.Authentication.Common;

public record RevokeTokenResult(
    bool IsSuccess,
    IReadOnlyCollection<string> Errors
);