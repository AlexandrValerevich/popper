namespace Shared.GifFile.Contracts.V1;

public static class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class GifFile
    {
        public const string GetGifFileById = Base + "/giffile/{id}";
        public const string CreateGifFile = Base + "/giffile";
        public const string DeleteGifFile = Base + "/giffile/{id}";
    }
}