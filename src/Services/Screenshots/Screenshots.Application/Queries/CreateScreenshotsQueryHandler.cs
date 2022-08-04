using MediatR;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;

namespace Screenshots.Application.Queries;

public class CreateScreenshotsQueryHandler : IRequestHandler<CreateScreenshotsQuery, ScreenshotsList>
{
    private readonly IScreenshotGenerator _screenshotGenerator;

    public CreateScreenshotsQueryHandler(IScreenshotGenerator browserExecutor)
    {
        _screenshotGenerator = browserExecutor;
    }

    public async Task<ScreenshotsList> Handle(CreateScreenshotsQuery request,
        CancellationToken token)
    {
        return await _screenshotGenerator.GenerateAsync(
            request.Uri,
            request.Selector,
            request.Duration,
            token);
    }
}