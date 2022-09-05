using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Poppers.Application.Common.Exceptions;

namespace Poppers.Api.Middlware;

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
                AppException e => Problem(context, e.Code, e.Message),
                ValidationException e => ValidationProblem(context, (int)HttpStatusCode.BadRequest, e.Message),
                _ => Problem(context, (int)HttpStatusCode.InternalServerError, "Internal error")
            };
        }
    }

    private static async Task Problem(HttpContext context, int statusCode, string massage)
    {
        var response = context.Response;
        response.StatusCode = statusCode;
        response.ContentType = "application/json";
        await response.WriteAsync(massage);
    }

    private static async Task ValidationProblem(HttpContext context, int statusCode, string massage)
    {
        var response = context.Response;
        response.StatusCode = statusCode;
        response.ContentType = "application/json";
        await response.WriteAsync(massage);
    }
}
