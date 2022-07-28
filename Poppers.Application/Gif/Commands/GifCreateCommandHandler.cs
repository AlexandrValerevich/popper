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

    public async Task<GifFile> Handle(GifCreateCommand request, CancellationToken cancellationToken)
    {
        GifDomain gif = _gifFactory.Create(
            Guid.NewGuid(),
            request.Duration,
            request.Delay,
            request.Uri,
            request.ElementSelector
        );

        ScreenshotList screenshots = await _screenshotCreator.TakeScreenshots(gif);
        IEnumerable<Frame> frames = screenshots.Value.Select(s =>
        {
            return new Frame(s.Value);
        });
        gif.AddRangeFrames(frames);

        var gifFile = await _gifFileGenerator.Generate(gif);
        return gifFile;
    }
}