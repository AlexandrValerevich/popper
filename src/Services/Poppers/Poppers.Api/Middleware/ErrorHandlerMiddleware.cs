using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Poppers.Application.Common.Exceptions;
using Poppers.Domain.Exceptions;

namespace Poppers.Api.Middleware;

#nullable enable

public class ErrorHandlerMiddleware : IMiddleware
{
    public readonly ProblemDetailsFactory _problemDetailsFactory;

    public ErrorHandlerMiddleware(ProblemDetailsFactory problemDetailsFactory)
    {
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }

        catch (Exception error)
        {
            _ = error switch
            {
                AppException e => Problem(context, e.Code, e.Title, e.Message),
                DomainException e => Problem(context, e.Code, e.Title, e.Message),
                ValidationException e => Problem(context, (int)HttpStatusCode.BadRequest, "Invalid request", e.Message),
                _ => Problem(context, (int)HttpStatusCode.InternalServerError, "Internal error")
            };
        }
    }

    private async Task Problem(HttpContext context, int statusCode, string title, string? details = null)
    {
        var problem = _problemDetailsFactory.CreateProblemDetails(
            httpContext: context,
            statusCode: statusCode,
            title: title,
            detail: details);

        var response = context.Response;
        response.StatusCode = statusCode;
        response.ContentType = "application/json";

        await response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}
