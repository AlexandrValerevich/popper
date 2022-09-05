namespace Poppers.Domain.ValueObjects.Gif;

public record FrameList
{
    public List<Frame> Value = new();

    public FrameList()
    {
    }

    public void Add(Frame screenshot)
    {
        Value.Add(screenshot);
    }
}