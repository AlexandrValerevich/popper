using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

public record Screenshot
{
    public byte[] Value { get; }

    public Screenshot(byte[] screenshot)
    {
        if (screenshot is null || screenshot.Length == 0)
        {
            throw new EmptyScreenshotException();
        }

        Value = screenshot;
    }
}