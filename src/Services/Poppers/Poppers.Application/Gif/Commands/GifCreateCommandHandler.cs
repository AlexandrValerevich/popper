using MediatR;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Poppers.Domain.Factory;
using Poppers.Domain.ValueObjects;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Gif.Commands;

public class GifCreateCommandHandler : IRequestHandler<GifCreateCommand, GifFile>
{
    private readonly IGifFactory _gifFactory;
    private readonly IScreenshotCreator _screenshotCreator;
    private readonly IGifFileGenerator _gifFileGenerator;

    public GifCreateCommandHandler(IGifFileGenerator gifFileGenerator,
        IScreenshotCreator screenshotCreator,
        IGifFactory gifFactory)
    {
        _gifFileGenerator = gifFileGenerator;
        _screenshotCreator = screenshotCreator;
        _gifFactory = gifFactory;
    }

    public async Task<GifFile> Handle(GifCreateCommand command, CancellationToken cancellationToken)
    {
        GifDomain gif = _gifFactory.Create(
            Guid.NewGuid(),
            command.Duration,
            command.Uri,
            command.ElementSelector
        );

        ScreenshotList screenshots = await _screenshotCreator.TakeScreenshots(gif);
        IEnumerable<Frame> frames = screenshots.Screenshots.Select(s =>
        {
            return new Frame(s);
        });
        gif.AddRangeFrames(frames);

        GifFile gifFile = await _gifFileGenerator.Generate(gif);
        return gifFile;
    }
}