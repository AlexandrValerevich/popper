using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Controllers;

namespace Poppers.Api.Controllers;

[ApiController]
public class PopperErrorController : ErrorControllerBase
{
    protected override (int statusCode, string title) HandleError()
    {
        Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;


        
        return exception switch
        {
            ValidationException e => (400, e.Message),
            _ => (500, "Internall Error")
        };
    }
}