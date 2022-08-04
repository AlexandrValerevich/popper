using Poppers.Application.Gif.Common;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Interfaces;

public interface IScreenshotCreator
{
    Task<ScreenshotList> TakeScreenshotsAsync(GifDomain gif, CancellationToken token);
}