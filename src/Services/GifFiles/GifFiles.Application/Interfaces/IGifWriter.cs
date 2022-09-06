using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifWriter
{
    Task CreateAsync(Gif gif, CancellationToken token);
    Task DeleteByIdAsync(Guid gifId, Guid userId, CancellationToken token);
    Task DeleteAllByUserIdAsync(Guid userId, CancellationToken token);
    Task RenameAsync(Guid gifId, Guid userId, string name, CancellationToken token);
}