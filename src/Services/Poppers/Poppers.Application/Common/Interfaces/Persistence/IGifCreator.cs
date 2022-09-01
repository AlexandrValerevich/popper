using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifCreator
{
    Task CreateAsync(GifDomain gif, CancellationToken token);
}