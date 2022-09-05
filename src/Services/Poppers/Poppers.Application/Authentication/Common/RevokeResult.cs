namespace Poppers.Application.Authentication.Common;

public record RevokeResult(
    bool IsSuccess,
    IReadOnlyCollection<string> Errors
);