using Poppers.Application.Gif.Common;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifFileWriter
{
    Task CreateAsync(GifDomain gif, Guid userId, ScreenshotList frames, CancellationToken token);
    Task DeleteAsync(Guid gifId, Guid userId, CancellationToken token);
    Task DeleteAllUserGifsAsync(Guid userId, CancellationToken token);
}