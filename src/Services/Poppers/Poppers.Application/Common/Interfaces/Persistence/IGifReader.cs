using Poppers.Application.Gif.Common;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifReader
{
    Task<IEnumerable<GifReadOnlyModel>> ReadAllUserGifsAsync(Guid userId, CancellationToken token);
}