using System.Net;

namespace Poppers.Application.Common.Exceptions;

public abstract class AppException : Exception
{
    public abstract int Code { get; } 
    public abstract string Title { get; } 

    protected AppException(string message) : base(message)
    {
    }
}