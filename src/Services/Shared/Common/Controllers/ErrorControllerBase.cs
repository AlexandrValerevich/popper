using Microsoft.AspNetCore.Mvc;

namespace Shared.Common.Controllers;


public abstract class ErrorControllerBase : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        var (code, title) = HandleError();

        

        return Problem(statusCode: code, title: title);
    }

    protected abstract (int statusCode, string title) HandleError();
}