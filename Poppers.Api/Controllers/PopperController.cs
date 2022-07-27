using Microsoft.AspNetCore.Mvc;

namespace Poppers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PopperController : ControllerBase
{
    public PopperController()
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
