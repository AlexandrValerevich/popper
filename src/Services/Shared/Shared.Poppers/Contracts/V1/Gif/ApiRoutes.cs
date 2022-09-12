namespace Shared.Poppers.Contracts.V1;

public static partial class ApiRoutes
{
    public static class Poppers
    {
        public const string GetGifById = Base + "/poppers/{gifId}";
        public const string GetAllUserPoppersById = Base + "/poppers";
        public const string CreateGif = Base + "/poppers";
        public const string DeleteGifById = Base + "/poppers/{gifId}";
        public const string DeleteAllUserGifs = Base + "/poppers";
    }
}