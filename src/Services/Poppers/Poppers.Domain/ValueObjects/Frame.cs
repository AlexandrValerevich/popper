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

    public static implicit operator byte[](Frame frame) => frame.Value;

    public static implicit operator Frame(byte[] frame) => new(frame);

}