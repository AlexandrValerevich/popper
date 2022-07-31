using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Factory;

public interface IGifFactory
{
    Gif Create(GifId id, Duration duration, Delay delay, GifUri uri, ElementSelector selector);
}