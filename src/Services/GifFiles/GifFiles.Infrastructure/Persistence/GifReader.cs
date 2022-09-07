using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifReader : IGifReader
{
    public Task<IEnumerable<Gif>> ReadAllAsync(Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}