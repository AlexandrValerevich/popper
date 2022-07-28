using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

public record Frame
{
    public byte[] Value { get; }

    public Frame(byte[] screenshot)
    {
        if (screenshot is null || screenshot.Length == 0)
        {
            throw new EmptyFrameException();
        }

        Value = screenshot;
    }
}