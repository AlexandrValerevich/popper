namespace Poppers.Domain.ValueObjects;

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