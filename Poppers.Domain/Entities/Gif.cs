using Poppers.Domain.ValueObjects;

namespace Poppers.Domain.Entities;

public class Gif
{
    public GifId Id;

    private readonly Duration _duration;

    private readonly Delay _delay;

    private readonly GifUri _uri;

    private readonly ElementSelector _elementSelector;

    private readonly FrameList _frames = new();

    internal Gif(GifId id, Duration duration, Delay delay, GifUri uri, ElementSelector selector)
    {
        Id = id;
        _duration = duration;
        _delay = delay;
        _uri = uri;
        _elementSelector = selector;
    }

    public IEnumerable<Frame> Frames => _frames.Value;

    public int Duration => _duration.Value;

    public int Delay => _delay.Value;

    public Uri Uri => _uri.Value;

    public string Selector => _elementSelector.Value;

    public void AddFrame(Frame frame)
    {
        _frames.Add(frame);
    }
}