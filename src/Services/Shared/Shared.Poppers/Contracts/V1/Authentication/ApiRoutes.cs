namespace Shared.Poppers.Contracts.V1;

public static partial class ApiRoutes
{
    public static class Authentication
    {
        public const string Login = Base + "/login";
        public const string Registration = Base + "/registration";
        public const string Refresh = Base + "/refresh";
        public const string Revoke = Base + "/revoke";
    }
}