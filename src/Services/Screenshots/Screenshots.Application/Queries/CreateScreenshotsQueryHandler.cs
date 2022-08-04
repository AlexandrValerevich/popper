using MediatR;
using Screenshots.Application.DTO;
using Screenshots.Application.Interfaces;

namespace Screenshots.Application.Queries;

public class CreateScreenshotsQueryHandler : IRequestHandler<CreateScreenshotsQuery, ScreenshotsListDTO>
{
    private readonly IScreenshotGenerator _screenshotGenerator;

    public CreateScreenshotsQueryHandler(IScreenshotGenerator browserExecutor)
    {
        _screenshotGenerator = browserExecutor;
    }

    public async Task<ScreenshotsListDTO> Handle(CreateScreenshotsQuery request,
        CancellationToken token)
    {
        return await _screenshotGenerator.Generate(
            request.Uri,
            request.Selector,
            request.Duration,
            token);
    }
}