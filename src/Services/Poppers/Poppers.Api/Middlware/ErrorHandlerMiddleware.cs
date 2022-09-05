using System.Net;
using System.Text.Json;
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
                ValidationException e => Problem(context, (int)HttpStatusCode.BadRequest, e.Message),
                _ => Problem(context, (int)HttpStatusCode.InternalServerError, "Internal error")
            };
        }
    }

    private async Task Problem(HttpContext context, int statusCode, string title)
    {
        var problem = _problemDetailsFactory.CreateProblemDetails(context, statusCode, title);
        var response = context.Response;
        response.StatusCode = statusCode;
        response.ContentType = "application/json";

        await response.WriteAsync(JsonSerializer.Serialize(problem));
    }

    // private  async Task ValidationProblem(HttpContext context, int statusCode, string title)
    // {
    //     var problem = _problemDetailsFactory.CreateValidationProblemDetails(context, );
    //     var response = context.Response;
    //     response.StatusCode = statusCode;
    //     response.ContentType = "application/json";
    //     await response.WriteAsync(title);
    // }
}
