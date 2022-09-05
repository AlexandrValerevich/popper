using ErrorOr;

namespace Poppers.Application.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error NotFound => Error.NotFound("Authentication.NotFound", "User not found.");
        public static Error IncorrectPassword => Error.Validation("Authentication.IncorrectPassword", "Invalid password");
        public static Error InvalidRefreshToken => Error.Validation("Authentication.InvalidRefreshToken", "Try to use invalid refresh token");
        public static Error InvalidRevokeToken => Error.Validation("Authentication.InvalidRevokeToken", "Try to revoke ");
        public static Error DuplicateEmail => Error.Conflict("Authentication.DuplicateEmail", "User with given email already exists.");

    }
}