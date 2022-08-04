using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Interfaces;

public interface IGifCreator
{
    Task CreateAsync(GifDomain gif, CancellationToken token);
}