using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.Gif;

namespace Poppers.Domain.Factory;

public interface IGifFactory
{
    Gif Create(GifId id, Duration duration, GifUri uri, ElementSelector selector);
}