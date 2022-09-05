using System.Net;

namespace Poppers.Application.Common.Exceptions;

public abstract class AppException : Exception
{
    public int Code { get; init; } = (int)HttpStatusCode.BadRequest;

    protected AppException(string message) : base(message)
    {
    }
}