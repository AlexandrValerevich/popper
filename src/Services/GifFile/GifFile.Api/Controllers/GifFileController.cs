using GifFile.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.GifFile.Contracts.V1;
using Shared.GifFile.Contracts.V1.Requests;

namespace GifFile.Api.Controllers;

[ApiController]
public class GifFileController : ControllerBase
{
    private readonly IGifFileGenerator _gifFileGenerator;

    public GifFileController(IGifFileGenerator gifFileGenerator)
    {
        _gifFileGenerator = gifFileGenerator;
    }

    [HttpGet(ApiRoutes.GifFile.GetGifFile)]
    public async Task<IActionResult> Get([FromQuery] GetGifFileRequest request)
    {
        var gifFile = await _gifFileGenerator.Generate(
            request.Images,
            request.Delay
        );

        return File(gifFile.FileStream, "image/gif");
    }
}
