using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifRemover : IGifRemover
{
    public ValueTask RemoveByIdAsync(Guid id, CancellationToken token)
    {
        var gifFileName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        File.Delete(gifFileName);

        return ValueTask.CompletedTask;
    }
}