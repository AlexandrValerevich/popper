using Poppers.Domain.ValueObjects.Gif;

namespace Poppers.Domain.Entities;

public class Gif
{
    public GifId Id;

    private readonly Duration _duration;
    private readonly GifUri _uri;
    private readonly ElementSelector _elementSelector;
    private readonly FrameList _frames = new();

    internal Gif(GifId id, Duration duration, GifUri uri, ElementSelector selector)
    {
        Id = id;
        _duration = duration;
        _uri = uri;
        _elementSelector = selector;
    }

    public IEnumerable<Frame> Frames => _frames.Value;

    public int Duration => _duration.Value;

    public Uri Uri => _uri.Value;

    public string Selector => _elementSelector.Value;

    public void AddFrame(Frame frame)
    {
        _frames.Add(frame);
    }

    public void AddRangeFrames(IEnumerable<Frame> frames)
    {
        foreach (Frame frame in frames)
        {
            _frames.Add(frame);
        }
    }
}