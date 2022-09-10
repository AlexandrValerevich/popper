namespace Shared.Poppers.Contracts.V1;

public static partial class ApiRoutes
{
    public static class Authentication
    {
        public const string Login = Base + "/auth/login";
        public const string Registration = Base + "/auth/registration";
        public const string Refresh = Base + "/auth/refresh";
        public const string Revoke = Base + "/auth/revoke";
    }
}