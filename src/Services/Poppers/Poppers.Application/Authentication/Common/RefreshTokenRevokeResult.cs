namespace Poppers.Application.Authentication.Common;

public record RefreshTokenRevokeResult(
    bool IsSuccess,
    IReadOnlyCollection<string> Errors
);