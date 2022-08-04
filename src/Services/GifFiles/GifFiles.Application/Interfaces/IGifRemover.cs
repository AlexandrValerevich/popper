namespace GifFiles.Application.Interfaces;

public interface IGifRemover
{
    ValueTask RemoveByIdAsync(Guid id, CancellationToken token);
}