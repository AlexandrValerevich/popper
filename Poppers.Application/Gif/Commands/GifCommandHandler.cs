using MediatR;
using Poppers.Application.Gif.Common;
using Poppers.Domain.Factory;

namespace Poppers.Application.Gif.Commands;

public class GifCommandHandler : IRequestHandler<GifCreateCommand, GifResult>
{
    private readonly IGifFactory _gifFactory;
    private readonly IScreenshotCreator _screenshotCreator;
    private readonly IGifGenerator _gifGenerator;

    public Task<GifResult> Handle(GifCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

internal interface IGifGenerator
{
}

internal interface IScreenshotCreator
{
}