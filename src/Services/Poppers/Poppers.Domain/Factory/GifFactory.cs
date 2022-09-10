using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.Gif;

namespace Poppers.Domain.Factory;

public class GifFactory : IGifFactory
{
    public Gif Create(GifId id,
        Duration duration,
        GifUri uri,
        ElementSelector selector,
        GifName name,
        DateTime creationDate)
    {
        return new Gif(id, name, duration, uri, selector, creationDate);
    }
}