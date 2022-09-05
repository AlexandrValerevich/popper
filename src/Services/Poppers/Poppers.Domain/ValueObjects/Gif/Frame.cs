using Poppers.Domain.Exceptions.Gif;

namespace Poppers.Domain.ValueObjects.Gif;

public record Frame
{
    public string Value { get; }

    public Frame(string screenshot)
    {
        if (screenshot is null || screenshot.Length == 0)
        {
            throw new EmptyFrameException();
        }

        Value = screenshot;
    }

    public static implicit operator string(Frame frame) => frame.Value;

    public static implicit operator Frame(string frame) => new(frame);

}