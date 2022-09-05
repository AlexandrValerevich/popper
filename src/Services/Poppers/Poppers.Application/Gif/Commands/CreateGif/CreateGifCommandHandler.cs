using MediatR;
using Poppers.Application.Common.Interfaces.Gif;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;
using Poppers.Domain.Factory;
using Poppers.Domain.ValueObjects.Gif;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Commands.CreateGif;

public class CreateGifCommandHandler : IRequestHandler<CreateGifCommand, GifCreationResult>
{
    private readonly IGifFactory _gifFactory;
    private readonly IScreenshotCreator _screenshotCreator;
    private readonly IGifWriter _gifWriter;

    public CreateGifCommandHandler(IGifWriter gifWriter,
        IScreenshotCreator screenshotCreator,
        IGifFactory gifFactory)
    {
        _gifWriter = gifWriter;
        _screenshotCreator = screenshotCreator;
        _gifFactory = gifFactory;
    }

    public async Task<GifCreationResult> Handle(CreateGifCommand command,
        CancellationToken token)
    {
        GifDomain gif = _gifFactory.Create(
            Guid.NewGuid(),
            command.Duration,
            command.Uri,
            command.ElementSelector
        );

        ScreenshotList screenshots = await _screenshotCreator.TakeScreenshotsAsync(gif, token);
        IEnumerable<Frame> frames = MapFrames(screenshots);
        gif.AddRangeFrames(frames);

        await _gifWriter.CreateAsync(gif, token);

        return new GifCreationResult(gif.Id);
    }

    private static IEnumerable<Frame> MapFrames(ScreenshotList screenshots)
    {
        return screenshots.Screenshots.Select(s =>
        {
            return new Frame(s);
        });
    }
}