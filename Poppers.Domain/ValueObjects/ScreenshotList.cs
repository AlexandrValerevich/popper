namespace Poppers.Domain.ValueObjects;

public record ScreenshotList
{
    public List<Screenshot> Value = new();

    public ScreenshotList()
    {
    }

    public void Add(Screenshot screenshot)
    {
        Value.Add(screenshot);
    }
}