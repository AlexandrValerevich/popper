using MediatR;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Poppers.Domain.Factory;
using Poppers.Domain.ValueObjects;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Commands;

public class CreateGifCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    private readonly IGifFactory _gifFactory;
    private readonly IScreenshotCreator _screenshotCreator;
    private readonly IGifCreator _gifFileCreator;

    public CreateGifCommandHandler(IGifCreator gifFileGenerator,
        IScreenshotCreator screenshotCreator,
        IGifFactory gifFactory)
    {
        _gifFileCreator = gifFileGenerator;
        _screenshotCreator = screenshotCreator;
        _gifFactory = gifFactory;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand command,
        CancellationToken cancellationToken)
    {
        GifDomain gif = _gifFactory.Create(
            Guid.NewGuid(),
            command.Duration,
            command.Uri,
            command.ElementSelector
        );

        ScreenshotList screenshots = await _screenshotCreator.TakeScreenshots(gif);
        IEnumerable<Frame> frames = MapFrames(screenshots);
        gif.AddRangeFrames(frames);

        await _gifFileCreator.Create(gif);

        return new GifCreationResult(gif.Id);
    }

    private static IEnumerable<Frame> MapFrames(ScreenshotList screenshots)
    {
        // Add mapster
        return screenshots.Screenshots.Select(s =>
        {
            return new Frame(s);
        });
    }
}