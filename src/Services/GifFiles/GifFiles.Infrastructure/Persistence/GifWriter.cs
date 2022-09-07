using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifWriter : IGifWriter
{
    public Task CreateAsync(Gif gif, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllByUserIdAsync(Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task RenameAsync(Guid gifId, Guid userId, string name, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}