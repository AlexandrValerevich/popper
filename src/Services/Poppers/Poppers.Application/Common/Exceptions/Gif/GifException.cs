namespace Poppers.Application.Common.Exceptions.Gif;

public abstract class GifException : AppException
{
    public GifException(string message) : base(message)
    {
    }
}