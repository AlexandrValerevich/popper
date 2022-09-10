using Poppers.Domain.ValueObjects.Gif;

namespace Poppers.Domain.Entities;

public class Gif
{
    public GifId Id;

    private readonly Duration _duration;
    private readonly GifUri _uri;
    private readonly ElementSelector _elementSelector;
    private readonly GifName _name;
    private readonly DateTime _created;

    internal Gif(
        GifId id,
        GifName name,
        Duration duration,
        GifUri uri,
        ElementSelector selector,
        DateTime created)
    {
        Id = id;
        _duration = duration;
        _uri = uri;
        _elementSelector = selector;
        _name = name;
        _created = created;
    }

    private Gif() { }

    public int Duration => _duration.Value;

    public Uri Uri => _uri.Value;

    public string Selector => _elementSelector.Value;

    public string Name => _name.Value;

    public DateTime Created => _created;
}