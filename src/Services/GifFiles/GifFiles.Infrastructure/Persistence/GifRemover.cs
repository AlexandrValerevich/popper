using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifRemover : IGifRemover
{
    public Task RemoveById(Guid id)
    {
        var gifFileName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        File.Delete(gifFileName);

        return Task.CompletedTask;
    }
}