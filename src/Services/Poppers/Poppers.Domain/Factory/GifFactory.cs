using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.Gif;

namespace Poppers.Domain.Factory;

public class GifFactory : IGifFactory
{
    public Gif Create(GifId id, Duration duration, GifUri uri, ElementSelector selector)
    {
        return new Gif(id, duration, uri, selector);
    }
}