using Microsoft.AspNetCore.Mvc;

namespace GifFile.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GifFileController : ControllerBase
{
    public GifFileController()
    {

    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
