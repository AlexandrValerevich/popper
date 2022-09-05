using System.Net;

namespace Poppers.Application.Common.Exceptions;

public abstract class ExceptionBase : Exception
{
    public int Code { get; init; } = (int)HttpStatusCode.BadRequest;

    protected ExceptionBase(string message) : base(message)
    {
    }
}